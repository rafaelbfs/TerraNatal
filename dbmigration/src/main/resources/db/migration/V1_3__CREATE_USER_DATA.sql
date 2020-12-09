CREATE TABLE ${flyway:defaultSchema}.BASE_USER
(
    "ID" SERIAL,
    "FEDERATED_IDENTIFIER" character varying(127),
    "EMAIL" character varying(127) NOT NULL,
    "NAME_OR_TRADEMARK" character varying(127) NOT NULL,
    "COUNTRY" character(3),
    "USER_CLASS" character(4),
    "TYPE" SMALLINT,
    CONSTRAINT "PK_USERS" PRIMARY KEY ("ID")
);

CREATE TABLE ${flyway:defaultSchema}.USER_EXT
(
    "CORP_ID" INTEGER,
    "MAIN_DOCUMENT_NR" character varying(22),
    "ISSUING_AUTHORITY" character varying(44),
    "ISSUING_COUNTRY" character (3),
    "CARE_OF" character varying(63),
    "ADDRESS_STREET" character varying(126),
    "ADDRESS_POSTAL_CODE" character varying(15),
    "ADDRESS_CITY_WITH_REGION" character varying(126),
    "ADDRESS_COUNTRY_IN_FULL" character varying(63),
    "PHONE_WITH_IDD_CODE" character varying(63),
    "MOBILE_WITH_IDD_CODE" character varying(63)
) INHERITS (BASE_USER);

CREATE TABLE ${flyway:defaultSchema}.CORPORATION
(
    "FULL_NAME_WITH_DENOMINATION" character varying(127) NOT NULL,
    "MAIN_DOCUMENT_NR" character varying(22),
    "ISSUING_AUTHORITY" character varying(44),
    "ISSUING_COUNTRY" character (3),
    "CARE_OF" character varying(63),
    "ADDRESS_STREET" character varying(126),
    "ADDRESS_POSTAL_CODE" character varying(15),
    "ADDRESS_CITY_WITH_REGION" character varying(126),
    "ADDRESS_COUNTRY_IN_FULL" character varying(63),
    "PHONE_WITH_IDD_CODE" character varying(63)
) INHERITS (BASE_USER);

CREATE TABLE ${flyway:defaultSchema}.ADMIN_USER
(
    "ADMIN_CLEARANCE" character(15),
    "ADMIN_CLEARANCE_LEVEL" INTEGER
) INHERITS (USER_EXT);

CREATE FUNCTION ${flyway:defaultSchema}.HAS_OWNER_RIGHTS(USER_ID INTEGER) RETURNS BOOLEAN 
LANGUAGE 'plpgsql'
AS $BODY$DECLARE
    C_OWNER_LEVEL CONSTANT SMALLINT := 5000;
BEGIN
  RETURN EXISTS(SELECT 1 FROM ${flyway:defaultSchema}.BASE_USER U WHERE U.ID = USER_ID AND U.TYPE >= C_OWNER_LEVEL);
END; $BODY$;

ALTER TABLE ${flyway:defaultSchema}.ACCOUNT_CHART
    ADD COLUMN "OWNER" integer;
