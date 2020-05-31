# Database migration

This section contains the sql scripts that will create the 
tables (including constraints), triggers and procedures in 
the database. Version control of the data and its definition is performed 
by Flyway. A sample config for migration to PostgreSQL at Google® Cloud 
is given in [the seed file](./seed_config_file.properties).

Observe that the [pom.xml](./pom.xml) refers to .properties files which do not 
exist in this repository as the files contain passwords to my own users in Postgre@Google Cloud.
Therefore you must create your own config files by replacing with your own config parameters.

If you will migrate data unto a local instance of postgre you can just use 
`flyway.url=jdbc:postgresql://localhost:5432/${finance.dbname}` pretty much ignoring all of 
all of the `conn.` properties. As long as you have `flyway.user` and `flyway.password set.