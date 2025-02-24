-- Table: public.CartsProductsItems

-- DROP TABLE IF EXISTS public."CartsProductsItems";

CREATE TABLE IF NOT EXISTS public."CartsProductsItems"
(
    "Id" uuid NOT NULL DEFAULT gen_random_uuid(),
    "CartId" uuid NOT NULL,
    "ProductId" uuid NOT NULL,
    "Quantity" integer NOT NULL,
    "UnitPrice" numeric NOT NULL,
    "TotalAmountItem" numeric NOT NULL,
    "Discounts" numeric NOT NULL,
    "Canceled" boolean DEFAULT false,
    CONSTRAINT "PK_CartsProductsItems" PRIMARY KEY ("Id"),
    CONSTRAINT "AK_CartsProductsItems_CartId_ProductId" UNIQUE ("CartId", "ProductId"),
    CONSTRAINT "FK_CartsProductsItems_Carts_CartId" FOREIGN KEY ("CartId")
        REFERENCES public."Carts" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
    CONSTRAINT "FK_CartsProductsItems_Product_ProductId" FOREIGN KEY ("ProductId")
        REFERENCES public."Product" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."CartsProductsItems"
    OWNER to usuario;
-- Index: IX_CartsProductsItems_ProductId

-- DROP INDEX IF EXISTS public."IX_CartsProductsItems_ProductId";

CREATE INDEX IF NOT EXISTS "IX_CartsProductsItems_ProductId"
    ON public."CartsProductsItems" USING btree
    ("ProductId" ASC NULLS LAST)
    WITH (deduplicate_items=True)
    TABLESPACE pg_default;