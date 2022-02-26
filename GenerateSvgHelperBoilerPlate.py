def CreateMap():
     res=[]
     for i in dirs:
             files = os.listdir(f'{src}\\{i}')
             for f in files:
                     res.append((f,''.join([x.title() for x in f[:-4].split('-')])))