import argparse 
from functions import *
Parser = argparse.ArgumentParser(
    prog = "ImageToAscii",
    description="Converts a given image into a text of ascii",
    epilog="Converts for use in white text by default use the -dark for dark text"
)
Parser.add_argument(
    'Filename', 
    type=str,
    help="The Image file path that you want to convert if it is equal to Camera then it will take a photo from the 1st camera available."
)
Parser.add_argument(
    'Scale',
    type=int,
    help="The Amount of Downscale the program uses when converting to a text file",
    default=8
)
Parser.add_argument(
    '-out',
    "--out",
    type=str,
    help="the output file name",
    default="New.txt",
)
Parser.add_argument(
    "-dark", 
    action="store_true"
)
if __name__ == "__main__":
    args = Parser.parse_args()
    if(args.Filename == "Camera"):
        cap = cv.VideoCapture(0)
        _, frame = cap.read();
        cv.imwrite("temp.png", frame)
        X = Pixelate("temp.png", args.Scale)
        if args.dark:
            SaveAs(args.out, BlackText(X))
        else:
            SaveAs(args.out, WhiteText(X))
        exit()
    X = Pixelate(args.Filename, args.Scale)
    
    if args.dark:
        SaveAs(args.out, BlackText(X))
    if not args.dark:
        SaveAs(args.out, WhiteText(X))


