PGDMP      	                |         	   ece_tsaak    17.2    17.2     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            �           1262    16581 	   ece_tsaak    DATABASE     }   CREATE DATABASE ece_tsaak WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Mexico.1252';
    DROP DATABASE ece_tsaak;
                     postgres    false            �            1259    16583    tc_enfermedad_cardiovascular    TABLE     6  CREATE TABLE admece.tc_enfermedad_cardiovascular (
    id_enf_cardiovascular integer NOT NULL,
    nombre character varying(100) NOT NULL,
    descripcion character varying(100) NOT NULL,
    fecha_registro date,
    fecha_inicio date,
    estado boolean DEFAULT true NOT NULL,
    fecha_actualizacion date
);
 0   DROP TABLE admece.tc_enfermedad_cardiovascular;
       admece         heap r       postgres    false            �            1259    16582 6   tc_enfermedad_cardiovascular_id_enf_cardiovascular_seq    SEQUENCE     �   CREATE SEQUENCE admece.tc_enfermedad_cardiovascular_id_enf_cardiovascular_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 M   DROP SEQUENCE admece.tc_enfermedad_cardiovascular_id_enf_cardiovascular_seq;
       admece               postgres    false    219            �           0    0 6   tc_enfermedad_cardiovascular_id_enf_cardiovascular_seq    SEQUENCE OWNED BY     �   ALTER SEQUENCE admece.tc_enfermedad_cardiovascular_id_enf_cardiovascular_seq OWNED BY admece.tc_enfermedad_cardiovascular.id_enf_cardiovascular;
          admece               postgres    false    218            &           2604    16586 2   tc_enfermedad_cardiovascular id_enf_cardiovascular    DEFAULT     �   ALTER TABLE ONLY admece.tc_enfermedad_cardiovascular ALTER COLUMN id_enf_cardiovascular SET DEFAULT nextval('admece.tc_enfermedad_cardiovascular_id_enf_cardiovascular_seq'::regclass);
 a   ALTER TABLE admece.tc_enfermedad_cardiovascular ALTER COLUMN id_enf_cardiovascular DROP DEFAULT;
       admece               postgres    false    218    219    219            �          0    16583    tc_enfermedad_cardiovascular 
   TABLE DATA           �   COPY admece.tc_enfermedad_cardiovascular (id_enf_cardiovascular, nombre, descripcion, fecha_registro, fecha_inicio, estado, fecha_actualizacion) FROM stdin;
    admece               postgres    false    219   o       �           0    0 6   tc_enfermedad_cardiovascular_id_enf_cardiovascular_seq    SEQUENCE SET     d   SELECT pg_catalog.setval('admece.tc_enfermedad_cardiovascular_id_enf_cardiovascular_seq', 8, true);
          admece               postgres    false    218            )           2606    16589 >   tc_enfermedad_cardiovascular tc_enfermedad_cardiovascular_pkey 
   CONSTRAINT     �   ALTER TABLE ONLY admece.tc_enfermedad_cardiovascular
    ADD CONSTRAINT tc_enfermedad_cardiovascular_pkey PRIMARY KEY (id_enf_cardiovascular);
 h   ALTER TABLE ONLY admece.tc_enfermedad_cardiovascular DROP CONSTRAINT tc_enfermedad_cardiovascular_pkey;
       admece                 postgres    false    219            �     x����N�0�g�)����&��]�00�\�Ke�؎�1t��b�AT)X�|:�w���-�kj%i����pF�1/ТP%Hj@���C�E�p0�ЁG}tТ�xAc��X�*�Y^dE9��2�7���yyu��h�iih�@0w��@q0M�La�r�������J�|�dZJS���u)��u_3Y3��rE[ϵ9{�f�y��w/���:��%M�X����>������ު��dc��au�ͅEΚ̅��%D6��0
ֽ�?�O7��OZ���     