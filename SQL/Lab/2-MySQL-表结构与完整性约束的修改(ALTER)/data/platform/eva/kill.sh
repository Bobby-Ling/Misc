# kill -9 `ps -ef | grep data | grep -v grep | awk -F' ' '{print $2}' `
list_descendants ()
{
  local children=$(ps -o pid= --ppid "$1")

  for pid in $children
  do
    list_descendants "$pid"
  done

  echo "$children"
}

kill $(list_descendants `ps -ef | grep execEva | grep -v grep | awk -F' ' '{print $2}'`)