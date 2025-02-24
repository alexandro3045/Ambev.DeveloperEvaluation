-- Table: public.Branch

-- DROP TABLE IF EXISTS public."Branch";

CREATE TABLE IF NOT EXISTS public."Branch"
(
    "Id" uuid NOT NULL DEFAULT gen_random_uuid(),
    "Description" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "CreatedAt" date NOT NULL,
    "UpdatedAt" date,
    CONSTRAINT "PK_Branch" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Branch"
    OWNER to usuario;