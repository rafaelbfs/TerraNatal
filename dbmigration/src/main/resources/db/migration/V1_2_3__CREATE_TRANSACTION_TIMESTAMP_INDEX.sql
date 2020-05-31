ALTER TABLE ${flyway:defaultSchema}.transactions
    ALTER COLUMN "TRAN_TIMESTAMP" SET DEFAULT CURRENT_TIMESTAMP;

ALTER TABLE ${flyway:defaultSchema}.transactions
    ALTER COLUMN "TRAN_TIMESTAMP" SET NOT NULL;


CREATE INDEX "IDX_TRANSACTION_TIMESTAMP"
    ON ${flyway:defaultSchema}.transactions USING btree
    ("TRAN_TIMESTAMP" ASC NULLS LAST);

