import pygame as py
from Classes import Grid, Text 
from random import shuffle
def Main():
    py.init()
    win = py.display.set_mode((500, 500))
    G1 = Grid((25, 25), (250, 250))
    G1.SetWindow(win)
    
    G1.Update()
    while True:
        
        win.fill((0,0,0))
        for ev in py.event.get():
            if ev.type == py.QUIT:
                return 
            if ev.type == py.MOUSEBUTTONDOWN and ev.button == 1:
                pass

        G1.Blit(win)
        py.display.flip()

Main()
py.quit()