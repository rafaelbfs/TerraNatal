package com.rafael.dao

import com.rafael.util.Flags
import slick.jdbc.JdbcProfile


class AccountBookDao(val profile: JdbcProfile) {
  import profile.api._
  case class AccountBook(id: Option[Long], code: String, name: String, description: String,
                         jurisdiction: String, sequenceNr: Int, flags: Int) {
    def synthetic = Flags.Synthetic(flags)
    def credit = Flags.Credit(flags)
    def debit = Flags.Debit(flags)
  }

  class AccountBookTbl(tag: Tag) extends Table[AccountBook](tag, "ACCOUNT_BOOK"){
    def id = column[Option[Long]]("ID", O.PrimaryKey, O.AutoInc)
    def code = column[String]("CODE", O.Length(16))
    def name = column[String] ("NAME", O.Length(64))
    def description = column[String]("DESCRIPTION", O.Length(128))
    def jurisdiction = column[String] ("JURISDICTION", O.Length(16))
    def sequenceNr = column[Int]("SEQUENCE_NR")
    def flags = column[Int]("FLAGS")

    def * = (id, code, name, description, jurisdiction, sequenceNr, flags) <>
      (AccountBook.tupled,  AccountBook.unapply)
  }

}
