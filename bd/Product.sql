-- Table: public.Product

-- DROP TABLE IF EXISTS public."Product";

CREATE TABLE IF NOT EXISTS public."Product"
(
    "Id" uuid NOT NULL DEFAULT gen_random_uuid(),
    "Title" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "Price" numeric NOT NULL,
    "Description" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "Category" character varying(20) COLLATE pg_catalog."default" NOT NULL,
    "Image" character varying(1000) COLLATE pg_catalog."default" NOT NULL,
    "Rating" jsonb NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "UpdatedAt" timestamp with time zone,
    CONSTRAINT "PK_Product" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Product"
    OWNER to usuario;