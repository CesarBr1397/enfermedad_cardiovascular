-- FUNCTION: admece.fn_get_all()

-- DROP FUNCTION IF EXISTS admece.fn_get_all();

CREATE OR REPLACE FUNCTION admece.fn_get_all(
	)
    RETURNS TABLE(id_enf_cardiovascular integer, nombre character varying, descripcion character varying, fecha_registro date, fecha_inicio date, estado boolean, fecha_actualizacion date) 
    LANGUAGE 'plpgsql'
    COST 100
    STABLE PARALLEL UNSAFE
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
        ec.estado = true
    ORDER BY
        ec.id_enf_cardiovascular ASC;
END;
$BODY$;

ALTER FUNCTION admece.fn_get_all()
    OWNER TO postgres;
