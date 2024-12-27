CREATE TABLE tc_enfermedad_cardiovascular (
    id_enf_cardiovascular SERIAL PRIMARY KEY,
    nombre VARCHAR(100),
    descripcion VARCHAR(100),
    fecha_registro DATE,
    fecha_inicio DATE,
    estado BOOLEAN NOT NULL DEFAULT TRUE,
    fecha_actualizacion DATE
);

CREATE OR REPLACE FUNCTION admece.fn_get_enfermedad_cardiovascular(p_id_enf_cardiovascular INTEGER)
RETURNS TABLE (
    id_enf_cardiovascular INTEGER,
    nombre VARCHAR(100),
    descripcion VARCHAR(100),
    fecha_registro DATE,
    fecha_inicio DATE,
    estado BOOLEAN,
    fecha_actualizacion DATE
) AS $$
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
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION admece.fn_Get_All()
RETURNS TABLE (
    id_enf_cardiovascular INTEGER,
    nombre VARCHAR(100),
    descripcion VARCHAR(100),
    fecha_registro DATE,
    fecha_inicio DATE,
    estado BOOLEAN,
    fecha_actualizacion DATE
) AS $$
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
        admece.tc_enfermedad_cardiovascular ec;
END;
$$ LANGUAGE plpgsql;




CREATE OR REPLACE FUNCTION admece.fn_agregar_enfermedad_cardiovascular(
    p_nombre character varying,
    p_descripcion character varying,
    p_fecha_registro date,
    p_fecha_inicio date,
    p_estado boolean,
    p_fecha_actualizacion date
)
RETURNS TABLE(
    id_enf_cardiovascular integer, 
    nombre character varying, 
    descripcion character varying, 
    fecha_registro date, 
    fecha_inicio date, 
    estado boolean, 
    fecha_actualizacion date
) 
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
    -- Inserta un registro en la tabla y retorna los valores insertados
    RETURN QUERY
    INSERT INTO admece."tc_enfermedad_cardiovascular" AS t
        (nombre, descripcion, fecha_registro, fecha_inicio, estado, fecha_actualizacion)
    VALUES
        (p_nombre, p_descripcion, p_fecha_registro, p_fecha_inicio, p_estado, p_fecha_actualizacion)
    RETURNING 
        t.id_enf_cardiovascular, t.nombre, t.descripcion, t.fecha_registro, t.fecha_inicio, t.estado, t.fecha_actualizacion;
END;
$BODY$;


CREATE OR REPLACE FUNCTION admece.fn_actualizar_enfermedad_cardiovascular(
    p_id_enf_cardiovascular integer,
    p_nombre character varying,
    p_descripcion character varying,
    p_estado boolean
)
RETURNS TABLE (
    id_enf_cardiovascular integer,
    nombre character varying,
    descripcion character varying,
    estado boolean
) AS $$
BEGIN
    RETURN QUERY
    UPDATE admece."tc_enfermedad_cardiovascular" AS t
    SET 
        nombre = COALESCE(p_nombre, t.nombre),
        descripcion = COALESCE(p_descripcion, t.descripcion),
        estado = COALESCE(p_estado, t.estado)
    WHERE t.id_enf_cardiovascular = p_id_enf_cardiovascular
    RETURNING 
        t.id_enf_cardiovascular, 
        t.nombre, 
        t.descripcion, 
        t.estado;
END;
$$ LANGUAGE plpgsql;




CREATE OR REPLACE FUNCTION admece.fn_borrar_logico_enfermedad_cardiovascular(
    p_id_enf_cardiovascular integer
)
RETURNS TABLE (
    id_enf_cardiovascular integer,
    nombre character varying,
    descripcion character varying,
    estado boolean
) AS $$
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
$$ LANGUAGE plpgsql;

