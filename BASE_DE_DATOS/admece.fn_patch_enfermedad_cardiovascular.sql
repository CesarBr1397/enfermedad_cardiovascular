-- FUNCTION: admece.fn_patch_enfermedad_cardiovascular(integer, character varying, character varying, date, boolean)

-- DROP FUNCTION IF EXISTS admece.fn_patch_enfermedad_cardiovascular(integer, character varying, character varying, date, boolean);

CREATE OR REPLACE FUNCTION admece.fn_patch_enfermedad_cardiovascular(
	p_id_enf_cardiovascular integer,
	p_nombre character varying,
	p_descripcion character varying,
	p_fecha_actualizacion date,
	p_estado boolean)
    RETURNS TABLE(id_enf_cardiovascular integer, nombre character varying, descripcion character varying, fecha_actualizacion date, estado boolean) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
BEGIN
    RETURN QUERY
    UPDATE admece."tc_enfermedad_cardiovascular" AS t
    SET 
        nombre = COALESCE(p_nombre, t.nombre),
        descripcion = COALESCE(p_descripcion, t.descripcion),
        estado = COALESCE(p_estado, t.estado),
		fecha_actualizacion = coalesce(p_fecha_actualizacion, current_date)
    WHERE t.id_enf_cardiovascular = p_id_enf_cardiovascular
    RETURNING 
        t.id_enf_cardiovascular, 
        t.nombre, 
        t.descripcion,
		t.fecha_actualizacion,
        t.estado
		;
END;
$BODY$;

ALTER FUNCTION admece.fn_patch_enfermedad_cardiovascular(integer, character varying, character varying, date, boolean)
    OWNER TO postgres;
