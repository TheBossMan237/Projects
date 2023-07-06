from typing import overload, Tuple
from pygame.font import Font
from pygame.sprite import Sprite
from pygame import Surface, Rect, Vector2
class Text:
    S = 0
    @staticmethod
    def DefualtSize(val : int):
        Text.S = val
    @overload
    def __init__(self,Size : int, _Text : str,Pos = (0,0), Color = (255, 255, 255)):
        self.T = Font(None, Size).render(_Text, True, Color)
        self._Text = _Text
        self.P = Pos
        self.R = Rect(Pos, self.T.get_size())
    def __init__(self, _Text : str, Pos = (0,0), Color = (255, 255, 255)):
        self.T = Font(None, Text.S).render(_Text, True, Color)
        self._Text = _Text
        self.P = Pos
        self.R = Rect(Pos, self.T.get_size())
    def Touching(self, Other : Tuple[int,int]): 
        if(self.R.collidepoint(Other)):
            return self._Text
        else:
            return None
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

