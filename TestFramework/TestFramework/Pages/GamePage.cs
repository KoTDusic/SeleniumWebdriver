﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.Pages
{
    public class GamePage
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "more_games")]
        private IWebElement more_games_button;
        [FindsBy(How = How.Id, Using = "below_game_favorite_link")]
        private IWebElement like_button;
        [FindsBy(How = How.Id, Using = "below_game_play_later_game")]
        private IWebElement playlist_button;
        [FindsBy(How = How.XPath, Using = "//ul[@id='nav_welcome_box']//span[@class='play-laters-count']")]
        private IWebElement playlist_counter;
        [FindsBy(How = How.XPath, Using = "//ul[@id='nav_welcome_box']//span[@class='favorites-count']")]
        private IWebElement like_counter;
        private string current_rating_locator = "//li[@id='quicklinks_star_ratings_block']/ul/li[1]";
        private string stars_list_locator = "//li[@id='quicklinks_star_ratings_block']/ul//li/a";
        private string recomended_game_list_locator = "//div[@id='more_games_tab_pane']/div/li/div//h4";

        public GamePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void MoreGamesClick()
        {
            more_games_button.Click();
        }
        public void OpenPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public bool CheckGameInRecommendedList(string game_name)
        {
            IReadOnlyCollection<IWebElement> game_tags =
                driver.FindElements(By.XPath(recomended_game_list_locator));
            foreach(IWebElement elem in game_tags)
            {
                if (String.Equals(elem.Text, game_name)) return true;
            }
            return false;
        }
        public string GetCurrentGameRate()
        {
            IWebElement colored_stars=driver.FindElement(By.XPath(current_rating_locator));
            return colored_stars.GetCssValue("width");
        }
        public void SetRate(int value)
        {
            IReadOnlyCollection<IWebElement> game_tags = driver.FindElements(By.XPath(stars_list_locator));
            game_tags.ElementAt(value-1).Click();
        }
        public string GetLikeCount()
        {
            return like_counter.Text.Trim();
        }
        public string GetPlaylistCount()
        {
            return playlist_counter.Text.Trim();
        }
        public void ChangeLikeStatus()
        {
            like_button.Click();
        }
        public void ChangePlaylistStatus()
        {
            playlist_button.Click();
        }
    }
}
