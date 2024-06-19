#!/bin/bash

evaLog="/data/workspace/eva.log"
stepMsg=$evaLog

evaTmpLog="/data/workspace/evaTmp.log"
evaStepMsg="{\"step\":"
export evaTmpLog
export evaStepMsg

sendMsg() {
    if [ "$2" ];
    then
        echo "{\"step\":\"$1\",\"ratio\":$2}"
    else
        echo "{\"step\":\"$1\"}"
    fi
}

sendCaseMsg() {
    caseTotal=${#ins[@]}
    let caseNum=$1+1
    if [[ $caseTotal -eq $caseNum ]];
    then
        return
    fi
    caseInfo="共$caseTotal个测试集，第$caseNum个测试集执行完成"
    if [ "$2" ];
    then
        let caseRatio=(100-$2)+$caseNum*$2/$caseTotal
        echo "{\"step\":\"$caseInfo\",\"ratio\":$caseRatio}"
    else
        echo "{\"step\":\"$caseInfo\"}"
    fi
}

# 更新业务程序执行信息
getEvaPidInfo() {
    evaPid=$(ps -p $eva_pid | grep $eva_pid)
}

#按行读取文件
readLine(){
    linenumThisTime=0
    readedLine=-1
    while read LINE
    do
        let linenumThisTime=linenumThisTime+1
        if [[ $linenumThisTime -lt $linenum ]];
        then
            continue
        else
            curline="$LINE"
            readedLine=0
            break
        fi
    done <$evaLog
}

#处理每行信息
processLine() {
    if [ $readedLine -eq 0 ];then
        match=$(echo $curline |grep -e "{\"step\":.*}")
        if [[ ! ${#match} -eq 0 ]]
        then
             echo $curline
        fi
        let linenum=linenum+1
    fi
}

#按行读取临时文件
readLineTmp(){
    linenumThisTimeTmp=0
    readedLineTmp=-1
    while read LINE
    do
        let linenumThisTimeTmp=linenumThisTimeTmp+1
        if [[ $linenumThisTimeTmp -lt $linenumTmp ]];
        then
            continue
        else
            curlineTmp="$LINE"
            readedLineTmp=0
            break
        fi
    done <$evaTmpLog
}

#处理每行信息
processLineTmp() {
    if [ $readedLineTmp -eq 0 ];then
        match=$(echo $curlineTmp |grep -e "{\"step\":.*}")
        if [[ ! ${#match} -eq 0 ]];
	    then
             echo $curlineTmp
        fi
        let linenumTmp=linenumTmp+1
    fi
}

handEvaTmpLog() {
    if [ -s $evaTmpLog ];
    then
        readLineTmp
        processLineTmp
    fi
}

#获取结果
getResult() {
    linenum=1
    linenumTmp=1
    readedLineTmp=-1
    getEvaPidInfo
    while :
    do
    if [ "$evaPid" ]
    then
        if [ -s $evaLog ]
        then
            #进程存在，并且日志文件已经写入内容，结束循环，后面去读取文件
            break
        else
            #进程存在，但日志文件不存在，等待进程创建文件，并写入内容
            sleep 1s
            getEvaPidInfo
        fi
    else
        if [ -s $evaLog ]
        then
            #进程不存在，但日志文件已经写入内容，结束循环，后面去读取文件。
            #这种情况是进程很快执行完成，正常情况下不会发生，可能是发生了错误。
            break
        else
            #进程不存在，日志文件也不存在，可能是进程还没有开始执行。
            #这种情况应该不存在,也可能进程发生了错误，不再执行，这样会一直持续到超时。
            sleep 1s
            getEvaPidInfo
        fi
    fi
    done

    #程序执行中，读取日志
    getEvaPidInfo
    while [ "$evaPid" ]
    do
        readLine
        processLine
        handEvaTmpLog
        if [[ ! $readedLine -eq 0 ]] && [[ ! $readedLineTmp -eq 0 ]];then
            sleep 1s
        fi
        getEvaPidInfo
    done

    #程序执行完成，读取evaTmpLog剩余分步消息
    handEvaTmpLog
    while [[ $readedLineTmp -eq 0 ]]
    do
        handEvaTmpLog
    done
    
    #程序执行完成，读取evaLog剩余分步消息
    readLine
    while [[ $readedLine -eq 0 ]]
    do
        processLine
        readLine
    done
    
    #最后结果
    if [ "$1" ];
    then
        result=$(cat $evaLog | grep -v $evaStepMsg)
    else
        result=$(cat $evaLog | grep -v $evaStepMsg | base64)
    fi
}

#清空evaLog文件,不能删除该文件,因为当evaTmpLog文件先输入信息时,会造成未能及时读取evaTmpLog文件的信息
echo '' > $evaLog
rm -rf $evaTmpLog
source /data/protectspace/evaluate.sh $1 $2 $3 $4 $5