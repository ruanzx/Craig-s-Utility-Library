﻿/*
Copyright (c) 2012 <a href="http://www.gutgames.com">James Craig</a>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

using Utilities.DataTypes.ExtensionMethods;
using System.Data;

namespace UnitTests.DataTypes.ExtensionMethods
{
    public class DateTimeExtension
    {
        [Fact]
        public void IsInFutureTest()
        {
            Assert.True(new DateTime(2100, 1, 1).IsInFuture());
        }

        [Fact]
        public void IsInPastTest()
        {
            Assert.True(new DateTime(1900, 1, 1).IsInPast());
        }

        [Fact]
        public void DaysLeftInMonthTest()
        {
            Assert.Equal(29, new DateTime(1999, 1, 2).DaysLeftInMonth());
        }

        [Fact]
        public void DaysLeftInYearTest()
        {
            Assert.Equal(363, new DateTime(1999, 1, 2).DaysLeftInYear());
        }

        [Fact]
        public void DaysLeftInWeekTest()
        {
            Assert.Equal(0, new DateTime(1999, 1, 2).DaysLeftInWeek());
        }

        [Fact]
        public void IsWeekDayTest()
        {
            Assert.False(new DateTime(1999, 1, 2).IsWeekDay());
        }

        [Fact]
        public void IsWeekEndTest()
        {
            Assert.True(new DateTime(1999, 1, 2).IsWeekEnd());
        }

        [Fact]
        public void FirstDayOfMonth()
        {
            Assert.Equal(new DateTime(1999, 1, 1), new DateTime(1999, 1, 2).FirstDayOfMonth());
        }

        [Fact]
        public void LastDayOfMonth()
        {
            Assert.Equal(new DateTime(1999, 1, 31), new DateTime(1999, 1, 2).LastDayOfMonth());
        }

        [Fact]
        public void DaysInMonth()
        {
            Assert.Equal(31, new DateTime(1999, 1, 2).DaysInMonth());
        }

        [Fact]
        public void FirstDayOfWeek()
        {
            Assert.Equal(new DateTime(1998, 12, 27), new DateTime(1999, 1, 2).FirstDayOfWeek());
        }

        [Fact]
        public void LastDayOfWeek()
        {
            Assert.Equal(new DateTime(1999, 1, 2), new DateTime(1999, 1, 2).LastDayOfWeek());
        }

        [Fact]
        public void EndOfDay()
        {
            Assert.Equal(new DateTime(1999, 1, 2, 23, 59, 59), new DateTime(1999, 1, 2, 12, 1, 1).EndOfDay());
        }

        [Fact]
        public void ToUnix()
        {
            Assert.Equal(915166800, new DateTime(1999, 1, 1).ToUnix());
        }

        [Fact]
        public void FromUnix()
        {
            Assert.Equal(new DateTime(2009, 2, 13, 23, 31, 30), 1234567890.FromUnixTime());
        }

        [Fact]
        public void UTCOffset()
        {
            Assert.Equal(-5, new DateTime(1999, 1, 2, 23, 1, 1, DateTimeKind.Local).UTCOffset());
        }

        [Fact]
        public void Age()
        {
            Assert.Equal(41, new DateTime(1940, 1, 1).Age(new DateTime(1981, 1, 1)));
        }

        [Fact]
        public void IsToday()
        {
            Assert.True(DateTime.Now.IsToday());
        }

        [Fact]
        public void SetTime()
        {
            Assert.Equal(new DateTime(2009, 1, 1, 14, 2, 12), new DateTime(2009, 1, 1, 2, 3, 4).SetTime(14, 2, 12));
        }

        [Fact]
        public void AddWeeks()
        {
            Assert.Equal(new DateTime(2009, 1, 15, 2, 3, 4), new DateTime(2009, 1, 1, 2, 3, 4).AddWeeks(2));
        }

        [Fact]
        public void ConvertToTimeZone()
        {
            Assert.Equal(new DateTime(2009, 1, 14, 23, 3, 4), new DateTime(2009, 1, 15, 2, 3, 4).ConvertToTimeZone(TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")));
        }

        [Fact]
        public void FirstDayOfYear()
        {
            Assert.Equal(new DateTime(2009, 1, 1, 0, 0, 0), new DateTime(2009, 1, 15, 2, 3, 4).FirstDayOfYear());
        }

        [Fact]
        public void LastDayOfYear()
        {
            Assert.Equal(new DateTime(2009, 12, 31, 0, 0, 0), new DateTime(2009, 1, 15, 2, 3, 4).LastDayOfYear());
        }

        [Fact]
        public void FirstDayOfQuarter()
        {
            Assert.Equal(new DateTime(2009, 1, 1), new DateTime(2009, 1, 15, 2, 3, 4).FirstDayOfQuarter());
            Assert.Equal(new DateTime(2009, 4, 1), new DateTime(2009, 4, 1, 2, 3, 4).FirstDayOfQuarter());
            Assert.Equal(new DateTime(2009, 1, 1), new DateTime(2009, 3, 29, 2, 3, 4).FirstDayOfQuarter());
            Assert.Equal(new DateTime(2009, 7, 1), new DateTime(2009, 7, 1, 2, 3, 4).FirstDayOfQuarter());
            Assert.Equal(new DateTime(2009, 4, 1), new DateTime(2009, 6, 29, 2, 3, 4).FirstDayOfQuarter());
            Assert.Equal(new DateTime(2009, 10, 1), new DateTime(2009, 10, 1, 2, 3, 4).FirstDayOfQuarter());
            Assert.Equal(new DateTime(2009, 7, 1), new DateTime(2009, 9, 29, 2, 3, 4).FirstDayOfQuarter());
            Assert.Equal(new DateTime(2010, 1, 1), new DateTime(2010, 1, 1).FirstDayOfQuarter());
            Assert.Equal(new DateTime(2009, 10, 1), new DateTime(2009, 12, 31, 2, 3, 4).FirstDayOfQuarter());
        }

        [Fact]
        public void LastDayOfQuarter()
        {
            Assert.Equal(new DateTime(2009, 3, 31), new DateTime(2009, 1, 15, 2, 3, 4).LastDayOfQuarter());
            Assert.Equal(new DateTime(2009, 6, 30), new DateTime(2009, 4, 1, 2, 3, 4).LastDayOfQuarter());
        }

        [Fact]
        public void RelativeTime()
        {
            Assert.Equal("34 years, 11 months from now", new DateTime(2011, 12, 1).RelativeTime(new DateTime(1977, 1, 1)));
            Assert.Equal("34 years, 11 months ago", new DateTime(1977, 1, 1).RelativeTime(new DateTime(2011, 12, 1)));
        }
    }
}
