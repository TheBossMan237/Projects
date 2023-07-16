from typing import overload, Tuple, Union
from pygame.font import Font
from pygame import Surface,Rect
class Text:
    S = 50
    @staticmethod
    def DefualtSize(Size : int):
        Text.S = Size

    @overload
    def __init__(self, text : str, size : int, Pos : tuple, Color : tuple): ...
    @overload
    def __init__(self, text : str, size : int, Pos : tuple ): ...
    @overload
    def __init__(self, text : str, size : int): ...
    @overload
    def __init__(self, text : str, Pos : tuple): ...
    @overload
    def __init__(self, text : str): ...
    def __init__(self, *Args):
        L = len(Args)
        match(len(Args)):
            case 1: 
                self.T = Font(None, Text.S).render(Args[0], True, (255, 255, 255))
                self.P = (0, 0)
            case 2: 
                if(type(Args[1]) == int):
                    self.T = Font(None, Args[1]).render(Args[0], True, (255, 255, 255))
                    self.P = (0,0)
                else: 
                    self.T = Font(None, Text.S).render(Args[0], True, (255, 255, 255))
                    self.P = Args[1]
            case 3: 
                self.T = Font(None, Args[1]).render(Args[0], True, (255, 255, 255))
                self.P = Args[2]
            case 4: 
                self.T = Font(None, Args[1]).render(Args[0], True, Args[3])
                self.P = Args[2]
            case _: raise SyntaxError("More Args then Specificed")
        self.text = Args[0]
        self.R = Rect(self.P, self.T.get_size())
    def Touching(self, Other : Union[Tuple[int, int], Rect]):
        if(type(Other) == tuple):
            if(self.R.collidepoint(Other)):
                return self.text
        else:
            if(self.R.colliderect(Other)):
                return self.text
    @property
    def Rend(self):
        self.R = Rect(self.P, self.T.get_size())
        return (self.T, self.R.topleft)
    @property
    def CenteredX(self):
        self.R.centerx = 250
        return (self.T, self.R.topleft)
    @property
    def CenteredY(self):
        self.R.centerty = 250
        return (self.T, self.R.topleft)
    

