namespace MaquinaDeCafeTests
{
    public class TestMaquinaDeCafe
    {
        Cafetera cafetera;
        Vaso vasosPequeno;
        Vaso vasosMediano;
        Vaso vasosGrande;
        Azucarero azucarero;
        MaquinaDeCafe maquinaDeCafe;

        [SetUp]
        public void SetUp()
        {
            cafetera = new Cafetera(50);
            vasosPequeno = new Vaso(5, 10);
            vasosMediano = new Vaso(5, 20);
            vasosGrande = new Vaso(5, 30);
            azucarero = new Azucarero(20);

            maquinaDeCafe = new MaquinaDeCafe();
            maquinaDeCafe.SetCafetera(cafetera);
            maquinaDeCafe.SetVasosPequeno(vasosPequeno);
            maquinaDeCafe.SetVasosMediano(vasosMediano);
            maquinaDeCafe.SetVasosGrande(vasosGrande);
            maquinaDeCafe.SetAzucarero(azucarero);
        }

        [Test]
        public void DeberiaDevolverUnVasoPequeno()
        {
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");
            Assert.AreEqual(maquinaDeCafe.VasosPequeno, vaso);
        }

        [Test]
        public void DeberiaRestarAzucar()
        {
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");
            maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);
            int resultado = maquinaDeCafe.Azucarero.CantidadAzucar;
            Assert.AreEqual(17, resultado);
        }

        [Test]
        public void DeberiaDevolverFelicitaciones()
        {
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");
            string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);
            Assert.AreEqual("Felicitaciones", resultado);
        }

        [Test]
        public void DeberiaRestarCafe()
        {
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");
            maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);
            int resultado = maquinaDeCafe.Cafetera.CantidadCafe;
            Assert.AreEqual(40, resultado);
        }

        [Test]
        public void DeberiaRestarVaso()
        {
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");
            maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);
            int resultado = maquinaDeCafe.VasosPequeno.CantidadVasos;
            Assert.AreEqual(4, resultado);
        }

        [Test]
        public void DeberiaDevolverNoHayCafe()
        {
            cafetera = new Cafetera(5);
            maquinaDeCafe.SetCafetera(cafetera);
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");
            string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 2);
            Assert.AreEqual("No hay Cafe", resultado);
        }

        [Test]
        public void DeberiaDevolverNoHayAzucar()
        {
            azucarero = new Azucarero(2);
            maquinaDeCafe.SetAzucarero(azucarero);
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");
            string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);
            Assert.AreEqual("No hay Azucar", resultado);
        }

        [Test]
        public void DeberiaDevolverUnVasoMediano()
        {
            MaquinaDeCafe maquinaDeCafe = new MaquinaDeCafe();
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("mediano");
            Assert.AreEqual(maquinaDeCafe.VasosMediano, vaso);
        }

        [Test]
        public void DeberiaDevolverUnVasoGrande()
        {
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("grande");
            Assert.AreEqual(maquinaDeCafe.VasosGrande, vaso);
        }

        [Test]
        public void DeberiaDevolverNoHayVasos()
        {
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");
            string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 10, 2);
            Assert.AreEqual("No hay Vasos", resultado);
        }
    }

    public class TestAzucarero
    {
        Azucarero azucarero;

        [SetUp]
        public void SetUp()
        {
            azucarero = new Azucarero(10);
        }

        [Test]
        public void DeberiadevolverVerdaderoSiHaySuficienteAzucarEnElAzucarero()
        {
            bool resultado = azucarero.HasAzucar(5);
            Assert.AreEqual(true, resultado);
            resultado = azucarero.HasAzucar(10);
            Assert.AreEqual(true, resultado);
        }

        [Test]
        public void DeberiadevolverFalsoPorqueNoHaySuficienteAzucarEnElAzucarero()
        {
            bool resultado = azucarero.HasAzucar(15);
            Assert.AreEqual(false, resultado);
        }

        [Test]
        public void DeberiaRestarAzucarAlAzucarero()
        {
            azucarero.GiveAzucar(5);
            Assert.AreEqual(5, azucarero.CantidadAzucar);
            azucarero.GiveAzucar(2);
            Assert.AreEqual(3, azucarero.CantidadAzucar);
        }
    }

    public class TestCafetera
    {
        Cafetera cafetera;

        [SetUp]
        public void SetUp()
        {
            cafetera = new Cafetera(10);
        }

        [Test]
        public void DeberiadevolverVerdaderoSiExisteCafe()
        {
            bool resultado = cafetera.HasCafe(5);
            Assert.AreEqual(true, resultado);
        }

        [Test]
        public void DeberiadevolverFalsoSiNoExisteCafe()
        {
            bool resultado = cafetera.HasCafe(11);
            Assert.AreEqual(false, resultado);
        }

        [Test]
        public void DeberiaRestarcafeALaCafetera()
        {
            cafetera.GiveCafe(7);
            Assert.AreEqual(3, cafetera.CantidadCafe);
        }
    }

    public class TestVaso
    {
        Vaso vasosPequenos;

        [SetUp]
        public void SetUp()
        {
            vasosPequenos = new Vaso(2, 10);
        }

        [Test]
        public void DeberiadevolverVerdaderoSiExistenVasos()
        {
            bool resultado = vasosPequenos.HasVasos(1);
            Assert.AreEqual(true, resultado);
            resultado = vasosPequenos.HasVasos(1);
            Assert.AreEqual(true, resultado);
        }

        [Test]
        public void DeberiadevolverFalsoSiNoExistenVasos()
        {
            bool resultado = vasosPequenos.HasVasos(2);
            Assert.AreEqual(false, resultado);
        }

        [Test]
        public void DeberiaRestarCantidadDeVaso()
        {
            vasosPequenos.GiveVasos(1);
            Assert.AreEqual(4, vasosPequenos.CantidadVasos);
        }
    }
}
