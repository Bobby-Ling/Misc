#!/bin/bash
echo "yes"


commit_img(){
        echo "$1" "$2" "$3" "$4" "$5" "$6" "$7" 
        local src_image="$1"
        local dest_image="$2"
        local tpi_id="$3"
        local user_id="$4"
        local encoded_variableMap="$5"
        local callback_url="$6"
        local new_image_name="$7"
        local status=""

        variableMap=$(echo "$encoded_variableMap" | base64 -d)

        # Commit源镜像到目标镜像
        nerdctl -nk8s.io commit "$src_image" "$dest_image"
        if [ $? -ne 0 ]; then
            status="-1"
        fi

        # Push目标镜像
        nerdctl -nk8s.io --insecure-registry push "$dest_image"
        if [ $? -eq 0 ]; then
            status="0"
        else
            status="-1"
        fi

        # 使用统一的CURL操作，并捕获返回结果
        curl_output=$(curl --request POST "$callback_url" --header 'Content-Type: multipart/form-data' \
            --form "tpiID=$tpi_id" --form "userId=$user_id" --form "newImageName=$new_image_name" \
            --form "status=$status" --form "variableMap=$variableMap" --form "msg=push $(if [ "$status" == "0" ]; then echo "sess"; else echo "faild"; fi)")

        # 输出curl操作的返回结果
        echo "CURL Output: $curl_output"
}

commit_img "$1" "$2" "$3" "$4" "$5" "$6" "$7" > push.log 2>&1 &
