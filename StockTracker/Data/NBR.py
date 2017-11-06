import requests
from bs4 import BeautifulSoup
import datetime

url = "https://www.marketwatch.com/investing/stock/NBR"
r = requests.get(url)

soup = BeautifulSoup(r.content, "html.parser")
span = soup.select('h3.intraday__price')[0]
price = span.select('bg-quote')[0].text.strip() #find_all('h3', 'class:intraday__price')



download_dir = "/Users/mitchellrsistrunk/Projects/MeechStocks/MeechStocks/Data/NBRHistory.csv" #where you want the file to be downloaded to 

now = datetime.datetime.now()
time = now.strftime("%Y-%m-%d %H:%M")

csv = open(download_dir, 'a') 
#'a' indicates you want to append to a file
csv.write(time + "," + price + "\n")