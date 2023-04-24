# vpass-util

### Vpassのサイトから利用明細を月ごとにダウンロードします
![image](https://user-images.githubusercontent.com/51302983/234056185-a1c89bb5-8568-4b1a-a99c-ffe8ff71316c.png)

## 対話モード
対話モードでは入力する必要がある値の入力をうながします
```bash
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
```bash
dotnet run download --cookie here --start 2022-02 --end 2023-04
```

## Cookie
F12押してリクエストを送って入手してください、有効期限は短いはずです(1時間ぐらい？？)

## 解析の例
重複の除いたすべての取引先(言いたいだけ)を表示
行ったことがあるお店が分かるのは結構いいと思う、このデータを使って行ったことあるお店を除外したご飯マップを作りたい
```csharp
 var csvFiles = Directory.GetFiles("./csv/", "*.csv").Select(File.ReadAllText);
 var rows = csvFiles.Select(x => x.Split(Environment.NewLine).SkipLast(2)).SelectMany(x => x).Select(x => x.Split(",").SkipLast(1).ToList());
 Console.WriteLine(string.Join(Environment.NewLine, rows.Where(x => x.Count == 6).Select(x => x[1]).Distinct().OrderBy(x => x)));
```
