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
            Assert.AreEqual("������ ������ � �������� ������", result.Item2);
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
            Assert.AreEqual("����� ������ ������ 5 ��������", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_ExistingUser()
        {
            // Arrange
            string login = "user11"; // ���� ������������ ��� ����������
            string password = "SecurePwd123";
            string password2 = "SecurePwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("������������ � ����� ������� ��� ���������������", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_InvalidLoginChars()
        {
            // Arrange
            string login = "user@123"; // ������������ ������� � ������
            string password = "SecurePwd123";
            string password2 = "SecurePwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("����� �������� �������, �������� �� ��������, ���� � ����� �������������", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_ValidEmailLogin()
        {
            // Arrange
            string login = "user@email.com"; // ���������� email-�����
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
            string login = "invalid-email"; // ������������ email-�����
            string password = "SecurePwd123";
            string password2 = "SecurePwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("Email �� ������������� ������ ������� xxx@xxx.xxx", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_ValidPhoneLogin()
        {
            // Arrange
            string login = "+1-123-456-7890"; // ���������� ����� ��������
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
            string login = "+1-123-456-789"; // ������������ ����� ��������
            string password = "SecurePwd123";
            string password2 = "SecurePwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("����� �������� �� ������������� ��������� ������� +x-xxx-xxx-xxxx", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_ValidPassword()
        {
            // Arrange
            string login = "user123";
            string password = "SecurePwd123"; // ���������� ������
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
            string password = "Pwd123"; // ������� �������� ������
            string password2 = "Pwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("����� ������ ������ 7 ��������", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_PasswordMismatch()
        {
            // Arrange
            string login = "user123";
            string password = "SecurePwd123";
            string password2 = "AnotherPwd123"; // ������ �� ���������

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("�������� ������ ���������", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_InvalidPasswordChars()
        {
            // Arrange
            string login = "user123";
            string password = "InvalidPassword!"; // ������������ ������� � ������
            string password2 = "InvalidPassword!";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("� ������ ������������ ������������ �������", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_PasswordMissingUppercase()
        {
            // Arrange
            string login = "user123";
            string password = "securepwd123"; // ������ ��� ��������� ����
            string password2 = "securepwd123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("� ������ ����������� ������� ���� ��������� �����", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_PasswordMissingLowercase()
        {
            // Arrange
            string login = "user123";
            string password = "SECUREPWD123"; // ������ ��� �������� ����
            string password2 = "SECUREPWD123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("� ������ ����������� ������� ���� �������� �����", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_PasswordMissingDigit()
        {
            // Arrange
            string login = "user123";
            string password = "SecurePwd"; // ������ ��� �����
            string password2 = "SecurePwd";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("� ������ ����������� ������� ���� �����", result.Item2);
        }

        [TestMethod]
        public void CheckRegister_PasswordMissingSpecialSymbol()
        {
            // Arrange
            string login = "user123";
            string password = "SecurePassword123"; // ������ ��� ������������ �������
            string password2 = "SecurePassword123";

            // Act
            var result = Register.CheckRegister(login, password, password2);

            // Assert
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("� ������ ����������� ������� ���� ����������� ������", result.Item2);
        }
    }
}
