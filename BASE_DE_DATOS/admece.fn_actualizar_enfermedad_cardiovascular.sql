-- FUNCTION: admece.fn_actualizar_enfermedad_cardiovascular(integer, character varying, character varying, boolean, date)

-- DROP FUNCTION IF EXISTS admece.fn_actualizar_enfermedad_cardiovascular(integer, character varying, character varying, boolean, date);

CREATE OR REPLACE FUNCTION admece.fn_actualizar_enfermedad_cardiovascular(
	p_id_enf_cardiovascular integer,
	p_nombre character varying,
	p_descripcion character varying,
	p_estado boolean,
	p_fecha_actualizacion date)
    RETURNS TABLE(id_enf_cardiovascular integer, nombre character varying, descripcion character varying, estado boolean, fecha_actualizacion date) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
BEGIN
    RETURN QUERY
    UPDATE admece.tc_enfermedad_cardiovascular
    SET 
        nombre = p_nombre,
        descripcion = p_descripcion,
        estado = p_estado,
        fecha_actualizacion = COALESCE(p_fecha_actualizacion, current_date)
    WHERE id_enf_cardiovascular = p_id_enf_cardiovascular
    RETURNING 
        id_enf_cardiovascular, 
        nombre, 
        descripcion, 
		estado,
        fecha_actualizacion;
END;
$BODY$;

ALTER FUNCTION admece.fn_actualizar_enfermedad_cardiovascular(integer, character varying, character varying, boolean, date)
    OWNER TO postgres;
