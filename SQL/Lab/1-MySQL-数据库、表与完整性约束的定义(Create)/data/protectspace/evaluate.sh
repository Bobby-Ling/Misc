#!/bin/bash
cd /data/workspace/myshixun

#前台传来的可执行文件，即测试文件
sourceClassNames=("src/step1/TestDb.sh" "src/step2/check.sh" "src/step3/check.sh" "src/step4/check.sh" "src/step5/test5.sh" "src/test6/test.sh")
input=$2;OLD_IFS="$IFS"; IFS=,; ins=($input);IFS="$OLD_IFS"

#不需要编译，设定编译结果为成功编译
compileResult=$(echo -n "compile successfully" | base64)

execute(){
    	# 循环检测数据库是否已启动
    	while :;
    	do
        	mysql -h127.0.0.1 -uroot -p123123 -e "show databases" 2>&1 >/dev/null
        	if [ $? -eq 0 ];then
            	break
        	else
            	sleep 1
        	fi
    	done
        executeCommand="bash "
        sourceClassName=${sourceClassNames[$1 - 1]}
        challengeStage=$1
	
	#get the loop times(looptimes = the num of testdataset)
        res_usage="{\"testSetUsages\":["
        output=''
        i=0
        while [[ i -lt ${#ins[*]} ]]; do
            #执行，并拼接执行结果
            #echo 0 > /sys/fs/cgroup/memory/memory.max_usage_in_bytes
            startTimeUsage=$(date +%s%N)
            result=$(echo "${ins[$i]}" | base64 -d | $executeCommand $sourceClassName 2>&1 | base64)
            #拼接输出结果
            endTimeUsage=$(date +%s%N)
            let testSetTimeUsage=$endTimeUsage-$startTimeUsage
            maxMemUsage=$(cat /sys/fs/cgroup/memory/memory.max_usage_in_bytes)
            res_usage="$res_usage{\"testSetTime\":\"$testSetTimeUsage\",\"testSetMem\":\"$maxMemUsage\"},"
            output=$output\"$result\",
            let i++
        done
        output="[${output%?}]"
}

execute $1
res_usage="${res_usage::-1}"
res_usage="$res_usage]}"
res_usage=$(echo -ne "$res_usage"|base64)
                
#return result in json format
returnResult(){
        result="{\"compileResult\":\"$compileResult\",\"out\":$output,\"resUsage\":\"$res_usage\"}"
        echo $result
}
#拼装成最终的json格式，echo输出得到最后结果
returnResult