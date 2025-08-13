#registry file path
$machinePolPath = "C:\Windows\System32\GroupPolicy\Machine\registry.pol"
$userPolPath = "C:\Windows\System32\GroupPolicy\User\registry.pol"

# モジュールのフルパスを指定してインポート
$modulePath = Join-Path -Path $PSScriptRoot -ChildPath "GPRegistryPolicyParser.psm1"
Import-Module $modulePath -Force

try {
  #ローカルグループポリシー(コンピューター)
  Parse-PolFile -Path $machinePolPath
}
catch {
  Write-Output ('Error     :' + $_.Exception.Message)
}

try {
  #ローカルグループポリシー(ユーザー)
  Parse-PolFile -Path $userPolPath
}
catch {
  Write-Output ('Error     :' + $_.Exception.Message)
}
