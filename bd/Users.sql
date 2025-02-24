-- Table: public.Users

-- DROP TABLE IF EXISTS public."Users";

CREATE TABLE IF NOT EXISTS public."Users"
(
    "Id" uuid NOT NULL DEFAULT gen_random_uuid(),
    "UserName" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "Name" jsonb NOT NULL,
    "Address" jsonb NOT NULL,
    "Email" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "Phone" character varying(20) COLLATE pg_catalog."default" NOT NULL,
    "Password" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "Role" character varying(20) COLLATE pg_catalog."default" NOT NULL,
    "Status" character varying(20) COLLATE pg_catalog."default" NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "UpdatedAt" timestamp with time zone,
    CONSTRAINT "PK_Users" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Users"
    OWNER to usuario;