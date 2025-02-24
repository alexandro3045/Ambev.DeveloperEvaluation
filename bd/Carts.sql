-- Table: public.Carts

-- DROP TABLE IF EXISTS public."Carts";

CREATE TABLE IF NOT EXISTS public."Carts"
(
    "Id" uuid NOT NULL DEFAULT gen_random_uuid(),
    "CreatedAt" date NOT NULL,
    "UserId" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_Carts" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Carts"
    OWNER to usuario;