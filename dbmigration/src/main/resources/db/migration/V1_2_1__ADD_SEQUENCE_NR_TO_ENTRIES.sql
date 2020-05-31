ALTER TABLE account_entries
    ADD COLUMN "SEQUENCE_NR" integer;

COMMENT ON COLUMN account_entries."SEQUENCE_NR"
    IS 'This is the sequence number of this entry within the account';