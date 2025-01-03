-- FUNCTION: admece.fn_borrar_logico_enfermedad_cardiovascular(integer)

-- DROP FUNCTION IF EXISTS admece.fn_borrar_logico_enfermedad_cardiovascular(integer);

CREATE OR REPLACE FUNCTION admece.fn_borrar_logico_enfermedad_cardiovascular(
	p_id_enf_cardiovascular integer)
    RETURNS TABLE(id_enf_cardiovascular integer, nombre character varying, descripcion character varying, estado boolean) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
BEGIN
    RETURN QUERY
    UPDATE admece."tc_enfermedad_cardiovascular" AS t
    SET 
        estado = false
    WHERE t.id_enf_cardiovascular = p_id_enf_cardiovascular
    RETURNING 
        t.id_enf_cardiovascular, 
        t.nombre, 
        t.descripcion, 
        t.estado;
END;
$BODY$;

ALTER FUNCTION admece.fn_borrar_logico_enfermedad_cardiovascular(integer)
    OWNER TO postgres;
