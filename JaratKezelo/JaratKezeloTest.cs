using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaratKezelo.test
{
    [TestFixture]
    class JaratKezeloTest
    {
        JaratKezelo j;
        DateTime time = new DateTime(2018, 08, 08, 12, 12, 12);

        [SetUp]
        public void Setup()
        {
            j = new JaratKezelo();
        }

        [Test]
        public void Járat()
        {
            j.UjJarat("tesztJaratSzam", "repter1", "repter2", DateTime.Now);
        }

        [Test]
        public void Duplikált()
        {
            j.UjJarat("tesztJaratSzam2", "repter1", "repter2", DateTime.Now);
            Assert.Throws<ArgumentException>(
                () =>
                {
                    j.UjJarat("tesztJaratSzam2", "repter3", "repter2", DateTime.Now);
                }
            );
        }

        [Test]
        public void VéglegesKesesNegativ()
        {
            j.UjJarat("tesztJaratSzam", "repter1", "repter2", DateTime.Now);
            Assert.Throws<NegativKesesExcepton>(
                () =>
                {
                    j.Keses("tesztJaratSzam", -5);
                }
            );
        }

        [Test]
        public void VéglegesKesesNemNegativ()
        {
            j.UjJarat("tesztJaratSzam", "repter1", "repter2", DateTime.Now);
            j.Keses("tesztJaratSzam", 50);
            j.Keses("tesztJaratSzam", -10);
        }

        [Test]
        public void JóTénylegesIndulas()
        {

            j.UjJarat("tesztJaratSzam", "repter1", "repter2", time);
            j.Keses("tesztJaratSzam", 50);
            j.Keses("tesztJaratSzam", -10);

            DateTime time2 = new DateTime(2018, 08, 08, 12, 52, 12);

            Assert.AreEqual(time2, time.AddMinutes(40));
        }

        [Test]
        public void RosszTénylegesIndulas()
        {

            j.UjJarat("tesztJaratSzam", "repter1", "repter2", time);
            j.Keses("tesztJaratSzam", 50);
            j.Keses("tesztJaratSzam", -10);

            DateTime time2 = new DateTime(2018, 08, 08, 12, 32, 12);

            Assert.AreNotEqual(time2, time.AddMinutes(40));
        }

        [Test]
        public void NemLétezőReptér()
        {

            j.UjJarat("tesztJaratSzam", "repter1", "repter2", time);
            j.UjJarat("tesztJaratSzam2", "repter1", "repter2", time);
            Assert.Throws<ArgumentException>(
                () =>
                {
                    j.JaratokRepuloterrol("repter3");
                }
            );
        }

        [Test]
        public void LétezőReptér()
        {

            j.UjJarat("tesztJaratSzam", "repter1", "repter2", time);
            j.UjJarat("tesztJaratSzam2", "repter1", "repter2", time);
            j.JaratokRepuloterrol("repter1");
        }

        [Test]
        public void MikorIndulRosszJáratszám()
        {

            j.UjJarat("tesztJaratSzam", "repter1", "repter2", time);
            Assert.Throws<ArgumentException>(
                () =>
                {
                    j.MikorIndul("tesztJaratSzam2");
                }
            );            
        }
    }
}
