from typing import overload, Tuple, Union
from pygame.font import Font
from pygame import Surface,Rect
class CLS_Prop(property):
    def __get__(self, cls, owner):
        return classmethod(self.fget).__get__(None, owner)()
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
class Grid:
    Defualt_Size = [500, 500]
    win = None
    @overload
    def __init__(self, C_Size : Tuple[int, int]):...
    @overload
    def __init__(self, C_Size : Tuple[int, int], G_Size : Tuple[int, int]):...
    def __init__(self, *Args):
        L = len(Args)
        self.image = Surface(Grid.Defualt_Size if L==1 else Args[1])
        self.List = [[]]
        self.Drawn = [[]]
        self.G_Pos = (0, 0)
        self.win = Grid.win
        self.G_Width, self.G_Height = (Grid.Defualt_Size if L == 1 else Args[1])
        self.C_Width, self.C_Height = Args[0]
        print(self.G_Width//self.C_Width, self.G_Height//self.C_Height)
        for X in range(0, (self.G_Width//self.C_Width)):
            for Y in range(0, (self.G_Height//self.C_Height)):
                self.List[-1].append(None)
            self.List.append([])
        self.List.pop(-1)
    @CLS_Prop
    def DefualtSize(cls):
        return cls.Defualt_Size
    @classmethod
    def SetWindow(cls, win : Surface):
        cls.win = win

    @DefualtSize.setter
    def DefualtSize(cls, val):
        if type(val) != list:
            raise TypeError(f"DefualtSize must be assigned to type List not {type(val)}")
        cls.Defualt_Size = val
    def __getitem__(self, index : Union[int, Tuple[int,int], slice]):
        T = type(index)
        if T == int or T == slice: return self.List[index]
        else: return self.List[index[0]][index[1]]
    def __setitem__(self, index : Union[int, Tuple[int, int], Tuple[slice, slice], slice], value :Surface):
        if value.get_size() != (self.C_Width, self.C_Height):
            raise ValueError("Value must fit in the cells")
        T = type(index)
        if T == tuple:
            T2 = type(index[0])
            if T2 == int:
                self.List[index[0]][index[1]] = value
                return 
            try:
                X_Range = range(
                    (index[0].start if index[0].start != None else 0), 
                    (index[0].stop if index[0].stop != None else len(self.List)), 
                    (index[0].step if index[0].step != None else 1)
                )
                Y_Range = range(
                    (index[1].start if index[1].start != None else 0), 
                    (index[1].stop if index[1].stop != None else len(self.List)), 
                    (index[1].step if index[1].step != None else 1)
                )
                for X in X_Range:
                    for Y in Y_Range:
                        self.List[X][Y] = value
                del X_Range, Y_Range
            except:
                raise IndexError("Index Out Of Range")
            del T2
            return
        if T == int: self.List[index] = value
        else:
            try:
                Lim_Y = len(self.List[0])
                X_Range = range(
                    (index.start if index.start != None else 0), 
                    (index.stop if index.stop != None else len(self.List)), 
                    (index.step if index.step != None else 1)
                )
                for X in X_Range:
                    for Y in range(0, Lim_Y):
                        self.List[X][Y] = value
            except:
                raise IndexError("Index Out Of Range")
    
    def Update(self, Index = None):
        if Index is None:
            for X in range(0, (self.G_Width//self.C_Width)):
                for Y in range(0, (self.G_Height//self.C_Height)):
                    E = self.List[X][Y]
                    if E == None: continue
                    self.image.blit(self.List[X][Y], (X*self.C_Width, Y*self.C_Height))
            return 
        print(self.List[Index[0]][Index[1]], Index[0]*self.C_Width, Index[1]*self.C_Height)
        self.image.blit(self.List[Index[0]][Index[1]], (Index[0]*self.C_Width, Index[1]*self.C_Height))
    def SetGlobalPosition(self, Pos : tuple):
        self.G_Pos = Pos
    def Blit(self, win = None, Pos = None):
        (win if win != None else Grid.win).blit(self.image, (Pos if Pos != None else self.G_Pos))
    def PosToIndex(self, pos : tuple):
        if pos[0] >= self.G_Pos[0] and pos[0] <= self.G_Pos[0] + self.G_Width and pos[1] >= self.G_Pos[1] and pos[1] <= self.G_Pos[1] + self.G_Height:
            Index_X = ((pos[0] - self.G_Pos[0]) // self.C_Width)
            Index_Y = ((pos[1] - self.G_Pos[1]) // self.C_Height)
            if(Index_X == self.G_Width // self.C_Width): Index_X -= 1
            if(Index_Y == self.G_Height // self.C_Height): Index_Y -= 1
            return (Index_X, Index_Y)
        return None
    

            
        