

ThisBuild / scalaVersion     := "2.13.2"
ThisBuild / version          := "0.1.0-SNAPSHOT"
ThisBuild / organization     := "com.rafael"
ThisBuild / organizationName := "rafael"

lazy val root = (project in file("."))
  .settings(
    name := "Sidonia",
    libraryDependencies ++= Seq(
      "com.typesafe.slick" %% "slick" % "3.3.2",
      "org.slf4j" % "slf4j-nop" % "1.7.26",
      "com.typesafe.slick" %% "slick-hikaricp" % "3.3.2",
      "org.postgresql" % "postgresql" % "42.2.5"
    )
  )
scalacOptions += "-deprecation"

// See https://www.scala-sbt.org/1.x/docs/Using-Sonatype.html for instructions on how to publish to Sonatype.
