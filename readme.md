# EasyNavi OSS について  
クロスプラットフォーム(Android/iOS)に対応したOSSの観光案内アプリテンプレートです。  
コンテンツをアプリ内に組み込んだスタンドアロンでの構成と、コンテンツ配信サーバーから最新の情報を取得る構成の両方の機能が用意されています。  
  
# Ignores.cs について
プロジェクト固有の情報を記述するファイルです。  
そのため、Gitの管理から外れる設定になっています。各自でプロジェクトに合わせて作成してください。  
テンプレートプロジェクトでは、コンテンツサーバーのURLを設定するようになっています。  
**作成例**  
```cs
using EasyNavi.Core.DataProviders.HttpDataProviders;
[assembly: HttpDataProviderHelper(BaseUri = "https://example.com/?resource={0}&contentid={1}")]
```  
  
# コンテンツ組み込みの場合のコンテンツファイルの作成について
ソリューション内の「ContentsManagement」プロジェクトがコンテンツファイル作成アプリ(Windowsデスクトップアプリケーション)のプロジェクトです。  
このプロジェクトをビルドして実行するとGUIでコンテンツファイルを作成できます。  
  
# コンテンツファイルの組み込みについて
上記コンテンツファイル作成アプリで作成したファイルで「EasyNavi.Core」プロジェクトのResources/LocalSourceData/ContentsData.zipを上書きしてください。  
EasyNavi.Core.SetUps.SetUpクラスのSetDIメソッドでSourceDataProviderクラスではなくLocalSourceDataProviderクラスを使用するように変更してください。  