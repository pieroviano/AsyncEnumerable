IF NOT DEFINED Configuration SET Configuration=Release
MSBuild.exe AsyncEnumerable.sln -t:clean
MSBuild.exe AsyncEnumerable.sln -t:restore -p:RestorePackagesConfig=true
MSBuild.exe AsyncEnumerable.sln -m /property:Configuration=%Configuration%
git add -A
git commit -a --allow-empty-message -m ''
git push