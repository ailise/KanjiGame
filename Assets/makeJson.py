import csv

# Establish our three file streams
krad = open('reducedkradfile.txt')
readings = open('kanjiReadings.csv')
outfile = open('moon_speak.json', 'w')

# Get an array of all the lines in kradfile
rads = krad.readlines()
# Create an empty dictionary
radDict = {}
# for loop iterates over each line in the kradfile
for line in rads:
# uses a kanji as a key for the radical dictionary, sets the value to the radicals
  radDict[line[:3]] = line[6:]

# start our JSON file with an open bracket
output = ["[\n\t"]
reader = csv.reader(readings)
print reader

# for each line in the hiragana file
for row in reader:
  # [:3] is a fancy way of saying everything before the 3rd index in the array, which it turns out is how unicode kanji works
  kanji = row[0]
  if kanji in radDict:
    # Set the kanji key
    print row[2]
    output.append("{\"kanji\" : \"" + kanji + "\",\n\t\t\t")
    # Set the hiragana data
    output.append("\"" + "hiragana" + "\" : \"" + row[2][:row[2].index(',')] + "\",\n\t\t\t")
    # Set the radical data. The .split() ensures that it comes out as an array
    output.append("\"" + "radicals" + "\" : [\"" + radDict[kanji].replace(" ", "\",\"")[:-1] + "\"],\n\t\t},\n\t\t")
  else:
    print kanji
# finish up our JSON
output.append("\n]")

# output to a file
outfile.writelines(output)
outfile.close()
