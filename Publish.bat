@echo off

git subtree split --prefix=Assets --branch UPM
git push origin UPM

echo Finish... 
pause