-- FUNCTION: ${flyway:defaultSchema}.update_account_sequence_nr_on_newentry()

-- DROP FUNCTION ${flyway:defaultSchema}.update_account_sequence_nr_on_newentry();

CREATE FUNCTION ${flyway:defaultSchema}.update_account_sequence_nr_on_newentry()
    RETURNS trigger
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE NOT LEAKPROOF
AS $BODY$DECLARE
  v_current_seq_nr integer;
BEGIN
	SELECT B."SEQUENCE_NR" INTO v_current_seq_nr FROM account_book B
	WHERE B."ID" = NEW."ACCOUNT_ID";

	v_current_seq_nr := v_current_seq_nr + 1;

	UPDATE account_book SET "SEQUENCE_NR" = v_current_seq_nr
	WHERE "ID" = NEW."ACCOUNT_ID";

	UPDATE account_entries SET "SEQUENCE_NR" = v_current_seq_nr
	WHERE "ACCOUNT_ID" = NEW."ACCOUNT_ID" AND "TRANID" = NEW."TRANID";

	RETURN NULL;
END; $BODY$;

ALTER FUNCTION ${flyway:defaultSchema}.update_account_sequence_nr_on_newentry()
    OWNER TO postgres;

GRANT EXECUTE ON FUNCTION ${flyway:defaultSchema}.update_account_sequence_nr_on_newentry() TO postgres;

GRANT EXECUTE ON FUNCTION ${flyway:defaultSchema}.update_account_sequence_nr_on_newentry() TO PUBLIC;

GRANT EXECUTE ON FUNCTION ${flyway:defaultSchema}.update_account_sequence_nr_on_newentry() TO ${appuser} WITH GRANT OPTION;

-- Trigger: update_account_sequence_nr_on_newentry

-- DROP TRIGGER update_account_sequence_nr_on_newentry ON ${flyway:defaultSchema}.account_entries;

CREATE TRIGGER update_account_sequence_nr_on_newentry
    AFTER INSERT
    ON ${flyway:defaultSchema}.account_entries
    FOR EACH ROW
    EXECUTE PROCEDURE ${flyway:defaultSchema}.update_account_sequence_nr_on_newentry();
