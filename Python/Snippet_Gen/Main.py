from json import load,dump,dumps
styleChar = "&#xFE0E;"
e = load(open("Main.json", "r", encoding="utf-8"))

e : dict[str, str]
out = {}
for x in e:
    code = hex(ord(e[x]))[1:]
    out[x] = {
        "scope" : "html,htmx",
        "prefix" : "&" + x.lower(),
        "description" : str(e[x]),
        "body" : [f'&#{code};{styleChar}']
    }
dump(out, open("C:/Users/wills/AppData/Roaming/Code/User/snippets/HTML.code-snippets", "w"))