#!/bin/bash
for solution in $(seq -w 1 25)
do
  for runCounter in $(seq 1 5)
  do
    filename="day${solution}/day${solution}.dll"
    if [[ -f $filename ]]; then
      echo "> Running solution $solution/25 run $runCounter/3"
      dotnet "${filename}"
      echo "> End running solution $solution/25 run $runCounter/3"
      sleep 5
    fi
    ((ctr++))
  done
done
