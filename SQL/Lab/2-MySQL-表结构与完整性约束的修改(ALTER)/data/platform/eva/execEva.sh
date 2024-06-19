#!/bin/bash
#清空用户日志输出文件
rm -f /data/workspace/user.out

function waitForNfs() {
    OLD_IFS="$IFS"; IFS=,; file_list=($2); IFS="$OLD_IFS"
    end=$(($(date +%s) + $1))
    while (( $(date +%s) <= end ))
    do
        count=0;
        for file in "${file_list[@]}"; do
            if [ -f "$file" ]; then
                ((count++))
            fi
        done

        if [ ${#file_list[@]} -eq "$count" ];then
            return
        else
            sleep 0.1
        fi
    done
}

if [ -n "$7" ]; then
  waitForNfs $1 $7 2>&1 1>/dev/null
fi

startCpuUsage=$(cat /sys/fs/cgroup/cpuacct/cpuacct.usage)
timeout $1 bash /data/platform/eva/execStepOut.sh $2 $3 $4 $5 $6
exitStatus=$?
if [ $exitStatus -eq 124 ] || [ $exitStatus -eq 137 ];then
	endCpuUsage=$(cat /sys/fs/cgroup/cpuacct/cpuacct.usage)
	let evaCpuUsage=$endCpuUsage-$startCpuUsage
	evaMaxMemUsage=$(cat /sys/fs/cgroup/memory/memory.max_usage_in_bytes)
	nodeLoadAvg=$(cat /proc/loadavg)
	echo "{\"exitStatus\":$exitStatus,\"evaCpuUsage\":$evaCpuUsage,\"evaMaxMemUsage\":$evaMaxMemUsage,\"nodeLoadAvg\":\"$nodeLoadAvg\"}"
fi