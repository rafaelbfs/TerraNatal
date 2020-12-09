--- GRANT PRIVILEGES TO APPUSER

--CREATE SCHEMA ${flyway:defaultSchema} AUTHORIZATION postgres;

GRANT ALL ON SCHEMA ${flyway:defaultSchema} TO ${appuser} WITH GRANT OPTION;

ALTER DEFAULT PRIVILEGES IN SCHEMA ${flyway:defaultSchema}
GRANT ALL ON TABLES TO ${appuser} WITH GRANT OPTION;

ALTER DEFAULT PRIVILEGES IN SCHEMA ${flyway:defaultSchema}
GRANT ALL ON SEQUENCES TO ${appuser} WITH GRANT OPTION;

ALTER DEFAULT PRIVILEGES IN SCHEMA ${flyway:defaultSchema}
GRANT EXECUTE ON FUNCTIONS TO ${appuser} WITH GRANT OPTION;

ALTER DEFAULT PRIVILEGES IN SCHEMA ${flyway:defaultSchema}
GRANT USAGE ON TYPES TO ${appuser} WITH GRANT OPTION;

CREATE TABLE ${flyway:defaultSchema}.ACCOUNT_CHART
(
    "ID" serial,
    "STANDARD" character varying(23),
    "COUNTRY_CODE" character(4),
    "DESCRIPTION" character varying(127),
    "FLAGS" integer,
    CONSTRAINT "PK_CHARTS" PRIMARY KEY ("ID")
);

-- CREATE ACCOUNT TABLE

CREATE TABLE ${flyway:defaultSchema}.ACCOUNT
(
    "ID" serial,
    "CHART" integer,
    "CODE" character varying(15) NOT NULL,
    "NAME" character varying(127),
    "DESCRIPTION" character varying(255),
    "FLAGS" integer,
    CONSTRAINT "PK_ACCOUNT" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_ACCTS_CHART" FOREIGN KEY ("CHART") REFERENCES ACCOUNT_CHART("ID")
);


