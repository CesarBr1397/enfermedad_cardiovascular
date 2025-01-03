-- Table: admece.tc_enfermedad_cardiovascular

-- DROP TABLE IF EXISTS admece.tc_enfermedad_cardiovascular;

CREATE TABLE IF NOT EXISTS admece.tc_enfermedad_cardiovascular
(
    id_enf_cardiovascular integer NOT NULL DEFAULT nextval('admece.tc_enfermedad_cardiovascular_id_enf_cardiovascular_seq'::regclass),
    nombre character varying(100) COLLATE pg_catalog."default" NOT NULL,
    descripcion character varying(100) COLLATE pg_catalog."default" NOT NULL,
    fecha_registro date,
    fecha_inicio date,
    estado boolean NOT NULL DEFAULT true,
    fecha_actualizacion date,
    CONSTRAINT tc_enfermedad_cardiovascular_pkey PRIMARY KEY (id_enf_cardiovascular)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS admece.tc_enfermedad_cardiovascular
    OWNER to postgres;