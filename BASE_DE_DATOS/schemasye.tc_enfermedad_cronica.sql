-- Table: schemasye.tc_enfermedad_cronica

-- DROP TABLE IF EXISTS schemasye.tc_enfermedad_cronica;

CREATE TABLE IF NOT EXISTS schemasye.tc_enfermedad_cronica
(
    id_enf_cronica integer NOT NULL DEFAULT nextval('schemasye.tc_enfermedad_cronica_id_enf_cronica_seq'::regclass),
    nombre character varying(255) COLLATE pg_catalog."default" NOT NULL,
    descripcion character varying(255) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    fecha_registro date DEFAULT CURRENT_DATE,
    fecha_inicio date DEFAULT CURRENT_DATE,
    estado boolean NOT NULL DEFAULT true,
    fecha_actualizacion date,
    CONSTRAINT tc_enfermedad_cronica_pkey PRIMARY KEY (id_enf_cronica)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS schemasye.tc_enfermedad_cronica
    OWNER to postgres;