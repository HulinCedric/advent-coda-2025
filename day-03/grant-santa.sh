#!/bin/bash

## Add execute permissions for the owner
chmod u+x backup.sh

## Remove execute permissions for group and others
chmod go-x backup.sh

## Remove write permissions for group and others
chmod go-w backup.sh