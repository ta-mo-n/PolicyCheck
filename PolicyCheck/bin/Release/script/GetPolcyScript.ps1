#registry file path
$machinePolPath = "C:\Windows\System32\GroupPolicy\Machine\registry.pol"
$userPolPath = "C:\Windows\System32\GroupPolicy\User\registry.pol"

# ���W���[���̃t���p�X���w�肵�ăC���|�[�g
$modulePath = Join-Path -Path $PSScriptRoot -ChildPath "GPRegistryPolicyParser.psm1"
Import-Module $modulePath -Force

try {
  #���[�J���O���[�v�|���V�[(�R���s���[�^�[)
  Parse-PolFile -Path $machinePolPath
}
catch {
  Write-Output ('Error     :' + $_.Exception.Message)
}

try {
  #���[�J���O���[�v�|���V�[(���[�U�[)
  Parse-PolFile -Path $userPolPath
}
catch {
  Write-Output ('Error     :' + $_.Exception.Message)
}
