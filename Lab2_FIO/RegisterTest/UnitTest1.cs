using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;

namespace Lab2_FIO.RegisterTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckRegister_ValidData()
        {
            // Arrange
            string login = "user123";
            string password = "SecurePwd123";
            string password2 = "SecurePwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("True", result.Item1);
            Assert.AreEqual("", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_EmptyLogin()
        {
            // Arrange
            string login = "";
            string password = "SecurePwd123";
            string password2 = "SecurePwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("Пустая строка в качестве логина", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_ShortLogin()
        {
            // Arrange
            string login = "user";
            string password = "SecurePwd123";
            string password2 = "SecurePwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("Длина логина меньше 5 символов", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_ExistingUser()
        {
            // Arrange
            string login = "user11"; // Этот пользователь уже существует
            string password = "SecurePwd123";
            string password2 = "SecurePwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("Пользователь с таким логином уже зарегистрирован", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_InvalidLoginChars()
        {
            // Arrange
            string login = "user@123"; // Недопустимые символы в логине
            string password = "SecurePwd123";
            string password2 = "SecurePwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("Логин содержит символы, отличные от латиницы, цифр и знака подчеркивания", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_ValidEmailLogin()
        {
            // Arrange
            string login = "user@email.com"; // Допустимый email-логин
            string password = "SecurePwd123";
            string password2 = "SecurePwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("True", result.Item1);
            Assert.AreEqual("", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_InvalidEmailLogin()
        {
            // Arrange
            string login = "invalid-email"; // Недопустимый email-логин
            string password = "SecurePwd123";
            string password2 = "SecurePwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("Email не удовлетворяет общему формату xxx@xxx.xxx", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_ValidPhoneLogin()
        {
            // Arrange
            string login = "+1-123-456-7890"; // Допустимый номер телефона
            string password = "SecurePwd123";
            string password2 = "SecurePwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("True", result.Item1);
            Assert.AreEqual("", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_InvalidPhoneLogin()
        {
            // Arrange
            string login = "+1-123-456-789"; // Недопустимый номер телефона
            string password = "SecurePwd123";
            string password2 = "SecurePwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("Номер телефона не удовлетворяет заданному формату +x-xxx-xxx-xxxx", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_ValidPassword()
        {
            // Arrange
            string login = "user123";
            string password = "SecurePwd123"; // Допустимый пароль
            string password2 = "SecurePwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("True", result.Item1);
            Assert.AreEqual("", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_ShortPassword()
        {
            // Arrange
            string login = "user123";
            string password = "Pwd123"; // Слишком короткий пароль
            string password2 = "Pwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("Длина пароля меньше 7 символов", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_PasswordMismatch()
        {
            // Arrange
            string login = "user123";
            string password = "SecurePwd123";
            string password2 = "AnotherPwd123"; // Пароли не совпадают

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("Заданные пароли совпадают", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_InvalidPasswordChars()
        {
            // Arrange
            string login = "user123";
            string password = "InvalidPassword!"; // Недопустимые символы в пароле
            string password2 = "InvalidPassword!";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("В пароле присутствуют недопустимые символы", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_PasswordMissingUppercase()
        {
            // Arrange
            string login = "user123";
            string password = "securepwd123"; // Пароль без заглавных букв
            string password2 = "securepwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("В пароле отсутствует минимум одна заглавная буква", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_PasswordMissingLowercase()
        {
            // Arrange
            string login = "user123";
            string password = "SECUREPWD123"; // Пароль без строчных букв
            string password2 = "SECUREPWD123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("В пароле отсутствует минимум одна строчная буква", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_PasswordMissingDigit()
        {
            // Arrange
            string login = "user123";
            string password = "SecurePwd"; // Пароль без цифры
            string password2 = "SecurePwd";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("В пароле отсутствует минимум одна цифра", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_PasswordMissingSpecialSymbol()
        {
            // Arrange
            string login = "user123";
            string password = "SecurePassword123"; // Пароль без специального символа
            string password2 = "SecurePassword123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("В пароле отсутствует минимум один специальный символ", result.Item2);
        }
    }
}
