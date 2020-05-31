package com.rafael.util

object Flags {

  class Flag (mask: Int) {
    def apply(value: Int):Boolean = (value & mask) != 0
    def !!():Int = mask
    def &+(other: Flag):Flag = new Flag(this.mask | other.mask)
  }

  private def flag(pt: Int): Flag = new Flag(pt)

  object Synthetic extends Flag(1)
  object Debit extends Flag(2)
  object Credit extends Flag(4)
  object Asset extends Flag((Debit &+ flag(8))!!)

}
