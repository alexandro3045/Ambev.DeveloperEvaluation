-- Table: public.SalesCarts

-- DROP TABLE IF EXISTS public."SalesCarts";

CREATE TABLE IF NOT EXISTS public."SalesCarts"
(
    "Id" uuid NOT NULL DEFAULT gen_random_uuid(),
    "SalesNumber" integer NOT NULL,
    "CreatedAt" date NOT NULL,
    "UpdatedAt" date NOT NULL,
    "UserId" uuid NOT NULL,
    "TotalSalesAmount" numeric NOT NULL,
    "BranchId" uuid NOT NULL,
    "CartId" uuid NOT NULL,
    "Quantities" integer NOT NULL,
    "Canceled" boolean NOT NULL,
    CONSTRAINT "PK_SalesCarts" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_SalesCarts_Branch_BranchId" FOREIGN KEY ("BranchId")
        REFERENCES public."Branch" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
    CONSTRAINT "FK_SalesCarts_Carts_CartId" FOREIGN KEY ("CartId")
        REFERENCES public."Carts" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
    CONSTRAINT "FK_SalesCarts_Users_UserId" FOREIGN KEY ("UserId")
        REFERENCES public."Users" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."SalesCarts"
    OWNER to usuario;
-- Index: IX_SalesCarts_BranchId

-- DROP INDEX IF EXISTS public."IX_SalesCarts_BranchId";

CREATE INDEX IF NOT EXISTS "IX_SalesCarts_BranchId"
    ON public."SalesCarts" USING btree
    ("BranchId" ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: IX_SalesCarts_CartId

-- DROP INDEX IF EXISTS public."IX_SalesCarts_CartId";

CREATE INDEX IF NOT EXISTS "IX_SalesCarts_CartId"
    ON public."SalesCarts" USING btree
    ("CartId" ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: IX_SalesCarts_UserId

-- DROP INDEX IF EXISTS public."IX_SalesCarts_UserId";

CREATE INDEX IF NOT EXISTS "IX_SalesCarts_UserId"
    ON public."SalesCarts" USING btree
    ("UserId" ASC NULLS LAST)
    TABLESPACE pg_default;