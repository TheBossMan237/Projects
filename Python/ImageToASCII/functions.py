from numpy import ndarray
import cv2 as cv
def Pixelate(filename : str, scale : int) -> ndarray:
    try:
        img = cv.imread(filename)
    except:
        raise "Invalid Filename please enter a filename that exists "
    
    h, w = img.shape[0] // scale, img.shape[1] // scale
    X = cv.resize(img, (w, h), interpolation=cv.INTER_LINEAR)
    X = cv.cvtColor(X, cv.COLOR_RGB2GRAY)
    return X
def BlackText(img):
    Array = [""]
    for x in img:

        for y in x:
            if y in range(0, 25):
                Array[-1] += "  "
            if y in range(25, 50):
                Array[-1] += "* "
            if y in range(50, 75):
                Array[-1] +="^ "
            if y in range(75, 100):
                Array[-1] += "! "
            if y in range(100, 125):
                Array[-1] += "/ "
            if y in range(125, 150):
                Array[-1] += "| "
            if y in range(150, 175):
                Array[-1] += "# "
            if y in range(175, 200):
                Array[-1] += "8 "
            if y > 200:
                Array[-1] += "@ "
        Array[-1] += "\n"
        Array.append("")
    return Array
def WhiteText(img):
    Array = [""]
    for x in img:

        for y in x:
            if y in range(0, 25):
                Array[-1] += "@ "
            if y in range(25, 50):
                Array[-1] += "# "
            if y in range(50, 75):
                Array[-1] +="$ "
            if y in range(75, 100):
                Array[-1] += "| "
            if y in range(100, 125):
                Array[-1] += "/ "
            if y in range(125, 150):
                Array[-1] += "! "
            if y in range(150, 175):
                Array[-1] += "* "
            if y in range(175, 200):
                Array[-1] += "^ "
            if y > 200:
                Array[-1] += "  "
        Array[-1] += "\n"
        Array.append("")
    return Array
def SaveAs(filename : str,data : list) -> None:
    with open(filename, "w") as f:
        f.writelines(data)


