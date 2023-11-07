using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace TestLogin
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SuccessLoginTest()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();

            val page = await browser.NewPageAsync();
            await page.GoToAsync("https://facebook.com/login");

            await page.FillAsync("#name", "testuser@gmail.com");
            await page.FillAsync("#name", "testpass");

            await page.ClickAsync("button[name='login']");

            val logoutButton = await page.WaitForSelectorAsync("#logoutButton");
            Assert.That(logoutButton, Is.Not.Null, "logout button should be present.");
        }
    }
}

