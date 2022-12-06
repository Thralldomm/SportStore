namespace SF2022UserLib.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
 

        [Test]
        public void Test1()
        {
            TimeSpan[] startTimes = new TimeSpan[5];

            startTimes[0] = new TimeSpan(10, 0, 0);
            startTimes[1] = new TimeSpan(11, 0, 0);
            startTimes[2] = new TimeSpan(15, 0, 0);
            startTimes[3] = new TimeSpan(15, 30, 0);
            startTimes[4] = new TimeSpan(16, 50, 0);

            int[] durations = new int[5];
            durations[0] = 60;
            durations[1] = 30;
            durations[2] = 10;
            durations[3] = 10;
            durations[4] = 40;

            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;



            Calculations c = new Calculations();

            string[] output = c.AvailablePeriods(
                               startTimes,
                               durations,
                               beginWorkingTime,
                               endWorkingTime,
                               consultationTime);

            string[] expected = {

                "08:00-08:30",
                "08:30-09:00",
                "09:00-09:30",
                "09:30-10:00",
                "11:30-12:00",
                "12:00-12:30",
                "12:30-13:00",
                "13:00-13:30",
                "13:30-14:00",
                "14:00-14:30",
                "14:30-15:00",
                "15:40-16:10",
                "16:10-16:40",
                "17:30-18:00"

            };

            Assert.AreEqual(expected, output);
        }
        
        
        [Test]
        public void Test2()
        {
            TimeSpan[] startTimes = new TimeSpan[5];

            startTimes[0] = new TimeSpan(8, 20, 0);
            startTimes[1] = new TimeSpan(10, 0, 0);
            startTimes[2] = new TimeSpan(13, 0, 0);
            startTimes[3] = new TimeSpan(15, 30, 0);
            startTimes[4] = new TimeSpan(16, 50, 0);

            int[] durations = new int[5];
            durations[0] = 30;
            durations[1] = 30;
            durations[2] = 10;
            durations[3] = 10;
            durations[4] = 40;

            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;



            Calculations c = new Calculations();

            string[] output = c.AvailablePeriods(
                               startTimes,
                               durations,
                               beginWorkingTime,
                               endWorkingTime,
                               consultationTime);

            string[] expected = {

                "08:50-09:20",
                "09:20-09:50",
                "10:30-11:00",
                "11:00-11:30",
                "11:30-12:00",
                "12:00-12:30",
                "12:30-13:00",
                "13:10-13:40",
                "13:40-14:10",
                "14:10-14:40",
                "14:40-15:10",
                "15:40-16:10",
                "16:10-16:40",
                "17:30-18:00"

            };

            Assert.AreEqual(expected, output);
        }



        [Test]
        public void Test3()
        {
            TimeSpan[] startTimes = new TimeSpan[5];

            startTimes[0] = new TimeSpan(10, 0, 0);
            startTimes[1] = new TimeSpan(11, 0, 0);
            startTimes[2] = new TimeSpan(15, 0, 0);
            startTimes[3] = new TimeSpan(16, 30, 0);
            startTimes[4] = new TimeSpan(18, 00, 0);

            int[] durations = new int[5];
            durations[0] = 60;
            durations[1] = 30;
            durations[2] = 30;
            durations[3] = 60;
            durations[4] = 30;

            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(19, 0, 0);
            int consultationTime = 30;



            Calculations c = new Calculations();

            string[] output = c.AvailablePeriods(
                               startTimes,
                               durations,
                               beginWorkingTime,
                               endWorkingTime,
                               consultationTime);

            string[] expected = {

                "08:00-08:30",
                "08:30-09:00",
                "09:00-09:30",
                "09:30-10:00",
                "11:30-12:00",
                "12:00-12:30",
                "12:30-13:00",
                "13:00-13:30",
                "13:30-14:00",
                "14:00-14:30",
                "14:30-15:00",
                "15:30-16:00",
                "16:00-16:30",
                "17:30-18:00",
                "18:30-19:00"

            };

            Assert.AreEqual(expected, output);
        }


        [Test]
        public void Test4()
        {
            TimeSpan[] startTimes = new TimeSpan[5];

            startTimes[0] = new TimeSpan(8, 0, 0);
            startTimes[1] = new TimeSpan(10, 0, 0);
            startTimes[2] = new TimeSpan(12, 0, 0);
            startTimes[3] = new TimeSpan(14, 0, 0);
            startTimes[4] = new TimeSpan(16, 0, 0);

            int[] durations = new int[5];
            durations[0] = 60;
            durations[1] = 60;
            durations[2] = 60;
            durations[3] = 60;
            durations[4] = 60;

            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(20, 0, 0);
            int consultationTime = 60;



            Calculations c = new Calculations();

            string[] output = c.AvailablePeriods(
                               startTimes,
                               durations,
                               beginWorkingTime,
                               endWorkingTime,
                               consultationTime);

            string[] expected = {

               
                "09:00-10:00",
                "11:00-12:00",
                "13:00-14:00",
                "15:00-16:00",
                "17:00-18:00",
                "18:00-19:00",
                "19:00-20:00"

            };

            Assert.AreEqual(expected, output);
        }


        [Test]
        public void Test5()
        {
            TimeSpan[] startTimes = new TimeSpan[5];

            startTimes[0] = new TimeSpan(13, 0, 0);
            startTimes[1] = new TimeSpan(14, 0, 0);
            startTimes[2] = new TimeSpan(15, 0, 0);
            startTimes[3] = new TimeSpan(16, 0, 0);
            startTimes[4] = new TimeSpan(17, 0, 0);

            int[] durations = new int[5];
            durations[0] = 10;
            durations[1] = 10;
            durations[2] = 10;
            durations[3] = 10;
            durations[4] = 60;

            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;



            Calculations c = new Calculations();

            string[] output = c.AvailablePeriods(
                               startTimes,
                               durations,
                               beginWorkingTime,
                               endWorkingTime,
                               consultationTime);

            string[] expected = {

                "08:00-08:30",
                "08:30-09:00",
                "09:00-09:30",
                "09:30-10:00",
                "10:00-10:30",
                "10:30-11:00",
                "11:00-11:30",
                "11:30-12:00",
                "12:00-12:30",
                "12:30-13:00",
                "13:10-13:40",
                "14:10-14:40",
                "15:10-15:40",
                "16:10-16:40"
            };

            Assert.AreEqual(expected, output);
        }


    
        /*
        [Test]
        public void Test6()
        {
            TimeSpan[] startTimes = new TimeSpan[5];

            startTimes[0] = new TimeSpan(10, 0, 0);
            startTimes[1] = new TimeSpan(11, 0, 0);
            startTimes[2] = new TimeSpan(15, 0, 0);
            startTimes[3] = new TimeSpan(15, 30, 0);
            startTimes[4] = new TimeSpan(16, 50, 0);

            int[] durations = new int[5];
            durations[0] = 60;
            durations[1] = 30;
            durations[2] = 10;
            durations[3] = 10;
            durations[4] = 40;

            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;



            Calculations c = new Calculations();

            string[] output = c.AvailablePeriods(
                               startTimes,
                               durations,
                               beginWorkingTime,
                               endWorkingTime,
                               consultationTime);

            string[] expected = {

                "08:00-08:30",
                "08:30-09:00",
                "09:00-09:30",
                "09:30-10:00",
                "11:30-12:00",
                "12:00-12:30",
                "12:30-13:00",
                "13:00-13:30",
                "13:30-14:00",
                "14:00-14:30",
                "14:30-15:00",
                "15:40-16:10",
                "16:10-16:40",
                "17:30-18:00"

            };

            Assert.AreEqual(expected, output);
        }



        [Test]
        public void Test7()
        {
            TimeSpan[] startTimes = new TimeSpan[5];

            startTimes[0] = new TimeSpan(10, 0, 0);
            startTimes[1] = new TimeSpan(11, 0, 0);
            startTimes[2] = new TimeSpan(15, 0, 0);
            startTimes[3] = new TimeSpan(15, 30, 0);
            startTimes[4] = new TimeSpan(16, 50, 0);

            int[] durations = new int[5];
            durations[0] = 60;
            durations[1] = 30;
            durations[2] = 10;
            durations[3] = 10;
            durations[4] = 40;

            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;



            Calculations c = new Calculations();

            string[] output = c.AvailablePeriods(
                               startTimes,
                               durations,
                               beginWorkingTime,
                               endWorkingTime,
                               consultationTime);

            string[] expected = {

                "08:00-08:30",
                "08:30-09:00",
                "09:00-09:30",
                "09:30-10:00",
                "11:30-12:00",
                "12:00-12:30",
                "12:30-13:00",
                "13:00-13:30",
                "13:30-14:00",
                "14:00-14:30",
                "14:30-15:00",
                "15:40-16:10",
                "16:10-16:40",
                "17:30-18:00"

            };

            Assert.AreEqual(expected, output);
        }


        [Test]
        public void Test8()
        {
            TimeSpan[] startTimes = new TimeSpan[5];

            startTimes[0] = new TimeSpan(10, 0, 0);
            startTimes[1] = new TimeSpan(11, 0, 0);
            startTimes[2] = new TimeSpan(15, 0, 0);
            startTimes[3] = new TimeSpan(15, 30, 0);
            startTimes[4] = new TimeSpan(16, 50, 0);

            int[] durations = new int[5];
            durations[0] = 60;
            durations[1] = 30;
            durations[2] = 10;
            durations[3] = 10;
            durations[4] = 40;

            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;



            Calculations c = new Calculations();

            string[] output = c.AvailablePeriods(
                               startTimes,
                               durations,
                               beginWorkingTime,
                               endWorkingTime,
                               consultationTime);

            string[] expected = {

                "08:00-08:30",
                "08:30-09:00",
                "09:00-09:30",
                "09:30-10:00",
                "11:30-12:00",
                "12:00-12:30",
                "12:30-13:00",
                "13:00-13:30",
                "13:30-14:00",
                "14:00-14:30",
                "14:30-15:00",
                "15:40-16:10",
                "16:10-16:40",
                "17:30-18:00"

            };

            Assert.AreEqual(expected, output);
        }

         
        [Test]
        public void Test9()
        {
            TimeSpan[] startTimes = new TimeSpan[5];

            startTimes[0] = new TimeSpan(10, 0, 0);
            startTimes[1] = new TimeSpan(11, 0, 0);
            startTimes[2] = new TimeSpan(15, 0, 0);
            startTimes[3] = new TimeSpan(15, 30, 0);
            startTimes[4] = new TimeSpan(16, 50, 0);

            int[] durations = new int[5];
            durations[0] = 60;
            durations[1] = 30;
            durations[2] = 10;
            durations[3] = 10;
            durations[4] = 40;

            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;



            Calculations c = new Calculations();

            string[] output = c.AvailablePeriods(
                               startTimes,
                               durations,
                               beginWorkingTime,
                               endWorkingTime,
                               consultationTime);

            string[] expected = {

                "08:00-08:30",
                "08:30-09:00",
                "09:00-09:30",
                "09:30-10:00",
                "11:30-12:00",
                "12:00-12:30",
                "12:30-13:00",
                "13:00-13:30",
                "13:30-14:00",
                "14:00-14:30",
                "14:30-15:00",
                "15:40-16:10",
                "16:10-16:40",
                "17:30-18:00"

            };

            Assert.AreEqual(expected, output);
        }

         
        [Test]
        public void Test10()
        {
            TimeSpan[] startTimes = new TimeSpan[5];

            startTimes[0] = new TimeSpan(10, 0, 0);
            startTimes[1] = new TimeSpan(11, 0, 0);
            startTimes[2] = new TimeSpan(15, 0, 0);
            startTimes[3] = new TimeSpan(15, 30, 0);
            startTimes[4] = new TimeSpan(16, 50, 0);

            int[] durations = new int[5];
            durations[0] = 60;
            durations[1] = 30;
            durations[2] = 10;
            durations[3] = 10;
            durations[4] = 40;

            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;



            Calculations c = new Calculations();

            string[] output = c.AvailablePeriods(
                               startTimes,
                               durations,
                               beginWorkingTime,
                               endWorkingTime,
                               consultationTime);

            string[] expected = {

                "08:00-08:30",
                "08:30-09:00",
                "09:00-09:30",
                "09:30-10:00",
                "11:30-12:00",
                "12:00-12:30",
                "12:30-13:00",
                "13:00-13:30",
                "13:30-14:00",
                "14:00-14:30",
                "14:30-15:00",
                "15:40-16:10",
                "16:10-16:40",
                "17:30-18:00"

            };

            Assert.AreEqual(expected, output);
        }*/
    }
}