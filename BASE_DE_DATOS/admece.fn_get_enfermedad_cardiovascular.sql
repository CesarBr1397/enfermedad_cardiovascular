-- FUNCTION: admece.fn_get_enfermedad_cardiovascular(integer)

-- DROP FUNCTION IF EXISTS admece.fn_get_enfermedad_cardiovascular(integer);

CREATE OR REPLACE FUNCTION admece.fn_get_enfermedad_cardiovascular(
	p_id_enf_cardiovascular integer)
    RETURNS TABLE(id_enf_cardiovascular integer, nombre character varying, descripcion character varying, fecha_registro date, fecha_inicio date, estado boolean, fecha_actualizacion date) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
BEGIN
    RETURN QUERY
    SELECT
        ec.id_enf_cardiovascular,
        ec.nombre,
        ec.descripcion,
        ec.fecha_registro,
        ec.fecha_inicio,
        ec.estado,
        ec.fecha_actualizacion
    FROM
        admece.tc_enfermedad_cardiovascular ec
    WHERE
        ec.id_enf_cardiovascular = p_id_enf_cardiovascular;
END;
$BODY$;

ALTER FUNCTION admece.fn_get_enfermedad_cardiovascular(integer)
    OWNER TO postgres;
