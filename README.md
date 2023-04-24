# vpass-util

### Vpassのサイトから利用明細を月ごとにダウンロードします
![image](https://user-images.githubusercontent.com/51302983/234056185-a1c89bb5-8568-4b1a-a99c-ffe8ff71316c.png)

## 対話モード
対話モードでは入力する必要がある値の入力をうながします
```
dotnet run download
```
![image](https://user-images.githubusercontent.com/51302983/234057064-f2795016-51ff-43cb-8efa-9d52d0341de5.png)

## 引数モード
引数モードでは対話しません
|  key  |  desription  |
| ---- | ---- |
|  cookie  |  cookie  |
|  start  |  yyyy-mm  |
|  end  |  yyyy-mm  |
```
dotnet run download --cookie here --start 2022-02 --end 2023-04
```

## Cookie
F12押してリクエストを送って入手してください、有効期限は短いはずです(1時間ぐらい？？)
