from selenium import webdriver
from selenium.webdriver.firefox.options import Options
from selenium.common.exceptions import NoSuchElementException
import subprocess

FireFoxOptions = Options()
FireFoxOptions.binary_location = "/usr/bin/firefox"
FireFoxOptions.headless = True
FireFoxOptions.log.level = "fatal"

browser = webdriver.Firefox(options=FireFoxOptions)
browser.get('https://www.bestbuy.com/site/sony-playstation-5-console/6426149.p')
try:
    stockbutton = browser.find_element_by_class_name("add-to-cart-button")
    stocktext = stockbutton.get_attribute("innerText")
    if "ADD TO CART" in stocktext.upper():
        print(stocktext)
        subprocess.Popen(["notify-send","PS5: Best Buy"])
    browser.close()
except NoSuchElementException:
    browser.close()
except:
    browser.close()

browser = webdriver.Firefox(options=FireFoxOptions)
browser.get('https://www.target.com/p/playstation-5-console/-/A-81114595')
try:
    stockbutton = browser.find_element_by_css_selector("div[data-test='flexible-fulfillment']")
    stocktext = stockbutton.get_attribute("innerText")
    if "SHIP IT" in stocktext.upper():
        print(stocktext)
        subprocess.Popen(["notify-send","PS5: Target"])
    browser.close()
except NoSuchElementException:
    browser.close()
except:
    browser.close()

browser = webdriver.Firefox(options=FireFoxOptions)
browser.get('https://www.walmart.com/ip/Sony-PlayStation-5-Video-Game-Console/994712501')
if "Error Page" != browser.title:
    try:
        stockbutton = browser.find_element_by_id("add-on-atc-container")
        stocktext = stockbutton.get_attribute("innerText")
        if "ADD TO CART" in stocktext.upper():
            print(stocktext)
            subprocess.Popen(["notify-send","PS5: Walmart"])
        browser.close()
    except NoSuchElementException:
       browser.close()
    except:
        browser.close()
    

browser = webdriver.Firefox(options=FireFoxOptions)
browser.get('https://www.amazon.com/PlayStation-5-Console/dp/B08FC5L3RG')
try:
    stockbutton = browser.find_element_by_id("availability")
    stocktext = stockbutton.get_attribute("innerText")
    if "IN STOCK" in stocktext.upper() and "CURRENTLY UNAVAILABLE" not in stocktext.upper():
        print(stocktext)
        subprocess.Popen(["notify-send","PS5: Amazon"])
    browser.close()
except NoSuchElementException:
    browser.close()
except:
    browser.close()

browser = webdriver.Firefox(options=FireFoxOptions)
browser.get('https://www.gamestop.com/video-games/playstation-5/consoles/products/playstation-5/11108140.html?condition=New')
try:
    stockbutton = browser.find_element_by_id("add-to-cart")
    stocktext = stockbutton.get_attribute("innerText")
    if "ADD TO CART" in stocktext.upper():
        print(stocktext)
        subprocess.Popen(["notify-send","PS5: Gamestop"])
    browser.close()
except NoSuchElementException:
    browser.close()
except:
    browser.close()
browser.quit()