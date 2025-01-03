-- FUNCTION: schemasye.actualizar_enfermedad(integer, character varying, character varying, boolean, date)

-- DROP FUNCTION IF EXISTS schemasye.actualizar_enfermedad(integer, character varying, character varying, boolean, date);

CREATE OR REPLACE FUNCTION schemasye.actualizar_enfermedad(
	p_id_enf_cronica integer,
	p_nombre character varying,
	p_descripcion character varying,
	p_estado boolean,
	p_fecha_actualizacion date)
    RETURNS TABLE(id_enf_cronica integer, nombre character varying, descripcion character varying, fecha_registro date, fecha_inicio date, estado boolean, fecha_actualizacion date) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
BEGIN
    RETURN QUERY
    UPDATE schemasye.tc_enfermedad_cronica AS t
    SET 
        nombre = p_nombre,
        descripcion = p_descripcion,
        estado = p_estado,
        fecha_actualizacion = COALESCE(p_fecha_actualizacion, current_date)
    WHERE t.id_enf_cronica = p_id_enf_cronica
    RETURNING 
        t.id_enf_cronica, 
        t.nombre, 
        t.descripcion, 
        t.fecha_registro,
        t.fecha_inicio,
        t.estado,
        t.fecha_actualizacion;
END;
$BODY$;

ALTER FUNCTION schemasye.actualizar_enfermedad(integer, character varying, character varying, boolean, date)
    OWNER TO postgres;
